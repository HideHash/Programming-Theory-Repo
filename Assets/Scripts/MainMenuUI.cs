using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class MainMenuUI : MonoBehaviour
{
    public Button startButton;
    public InputField nameInputField;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckNameEntry();
    }

    void CheckNameEntry()
    {
        if (!nameInputField.text.Equals(""))
        {
            startButton.interactable = true;
        }
        else
        {
            startButton.interactable = false;
        }
    }


    public void StartGame()
    {
        Debug.Log("hello starg");
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
        Debug.Log("hello quit");
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
}
