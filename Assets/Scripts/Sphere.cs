using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : Shape
{
    // Start is called before the first frame update
    void Start()
    {
        m_shapeName = "Sphere";
    }
    // Update is called once per 
    void Update()
    {
        Move();
    }

    public override void Move()
    {
        transform.Translate(Vector3.up * 0.001f * Mathf.Sin(Time.time));
    }

}
