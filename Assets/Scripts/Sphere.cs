using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : Shape // INHERITANCE
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

    public override void Move() // POLYMORPHISM
    {
        transform.Translate(Vector3.up * 0.001f * Mathf.Sin(Time.time));
    }

}
