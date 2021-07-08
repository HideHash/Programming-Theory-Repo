using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Shape // INHERITANCE
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

    public override void Move() // POLYMORPHISM
    {
        transform.Rotate(Vector3.up * 30.0f * Time.deltaTime);
    }
}
