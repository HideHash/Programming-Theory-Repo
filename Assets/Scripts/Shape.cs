using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shape : MonoBehaviour
{
    public Color m_color { get; protected set; } // ENCAPSULATION
    public string m_shapeName { get; protected set; } // ENCAPSULATION
    public abstract void Move();

    public void SetRandomColor()
    {
        m_color = Helper.GetRandomColor();
        gameObject.GetComponent<Renderer>().material.color = m_color;
    }

    public void SetColor(Color color)
    {
        m_color = color;
        gameObject.GetComponent<Renderer>().material.color = m_color;
    }

    void UpdateScore()
    {
        MainSequencer mainSequencer = GameObject.Find("MainSequencer").GetComponent<MainSequencer>();
        mainSequencer.CheckAnswer(this);
    }

    private void OnMouseDown()
    {
        UpdateScore();
    }
}
