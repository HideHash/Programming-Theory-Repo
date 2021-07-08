using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : Shape // INHERITANCE
{
    // Start is called before the first frame update
    void Start()
    {
        m_shapeName = "Cuplse";
    }
    // Update is called once per 
    void Update()
    {
        Move();
    }

    public override void Move() // POLYMORPHISM
    {
        transform.Rotate(Vector3.forward * 30.0f * Time.deltaTime);
    }
}
