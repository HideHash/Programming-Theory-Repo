using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leader : MonoBehaviour
{
    public Shape[] prefabs;

    private Vector3 spawnPos = new Vector3(0.0f, 2.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        CreateRandomShape();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateRandomShape()
    {
        int shapeID = Random.Range(0, prefabs.Length);
        Shape s = Instantiate(prefabs[shapeID], spawnPos, prefabs[shapeID].transform.rotation);
        s.SetRandomColor();
    }
}
