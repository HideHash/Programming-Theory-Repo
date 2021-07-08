using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSequencer : MonoBehaviour
{
    private bool isGameActive = false;
    public Shape[] prefabs;

    private Shape leader;
    private Shape[] Selector = new Shape[3];

    private Vector3 LeaderSpawnPos = new Vector3(0.0f, 2.0f, 0.0f);
    private Vector3[] SelectorSpawnPos = new Vector3[]
    {
        new Vector3(-5.0f, -2.0f, 0.0f),
        new Vector3(0.0f, -2.0f, 0.0f),
        new Vector3(5.0f, -2.0f, 0.0f),
    };

    public Text askTypeText;  // Question type asking Color or Shape
    private bool isAskingColor = true;

    private bool isAnswered = false;

    public Text scoreText;
    public int score { get; private set; }

    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        CreateSelectors();
        InvokeRepeating("StartQuestion", 2.0f, 3.0f);
        isGameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartQuestion()
    {
        if (isGameActive)
        {
            RandomizeQuestionType();
            CreateLeader();
            float t = 2.0f;
            StartCoroutine("EndQuestion", t);
            isAnswered = false;
        }
    }

    IEnumerator EndQuestion(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        askTypeText.gameObject.SetActive(false);
        Destroy(leader.gameObject);
    }

    void CreateLeader() // ABSTRACTION
    {
        int shapeId = Random.Range(0, prefabs.Length);
        leader = Instantiate(prefabs[shapeId], LeaderSpawnPos, prefabs[shapeId].transform.rotation);
        leader.SetRandomColor();
    }

    void CreateSelectors() // ABSTRACTION
    {
        int[] numbers = new int[] { 0, 1, 2 };
        int[] orderShape = Helper.ShuffleArray(numbers);
        int[] orderColor = Helper.ShuffleArray(numbers);

        for (int i = 0; i < 3; i++)
        {
            Selector[i] = Instantiate(prefabs[orderShape[i]], SelectorSpawnPos[i], prefabs[orderShape[i]].transform.rotation);
            Selector[i].SetColor(Helper.ColorArray[orderColor[i]]);
        }
    }

    void RandomizeQuestionType()
    {
        int R = Random.Range(0, 2);

        if(R == 0) {
            isAskingColor = true;
            askTypeText.text = "Color";
        }
        else
        {
            isAskingColor = false;
            askTypeText.text = "Shape";
        }

        askTypeText.gameObject.SetActive(true);
    }

    public void CheckAnswer(Shape shape)
    {
        if (isGameActive && !isAnswered)
        {
            if (isAskingColor)
            {
                if (leader.m_color == shape.m_color)
                {
                    UpdateScore(5);
                    isAnswered = true;
                }
                else
                {
                    GameOver();
                }
            }
            else
            {
                if (leader.m_shapeName == shape.m_shapeName)
                {
                    UpdateScore(5);
                    isAnswered = true;
                }
                else
                {
                    GameOver();
                }
            }
        }
    }

    void UpdateScore(int add)
    {
        score += add;
        scoreText.text = "Score:" + score;
    }

    void GameOver()
    {
        isGameActive = false;
        gameOverPanel.gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitMain()
    {
        SceneManager.LoadScene(0);
    }
}
