using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Shape
{
    // Start is called before the first frame update
    void Start()
    {
        m_shapeName = "Cube";
    }
    // Update is called once per 
    void Update()
    {
        Move();
    }

    public override void Move()
    {
        transform.Rotate(Vector3.up * 30.0f * Time.deltaTime);
    }
}
