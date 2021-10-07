using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private float _constantSpeed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveBall();
    }


    private void MoveBall()
    {
        float rand = Random.Range(0, 2);
        Vector2 vel;
        if (rand < 1.0f)
        {
            vel = new Vector2(_constantSpeed, _constantSpeed / 2).normalized * _constantSpeed;
        }
        else
        {
            vel = new Vector2(-_constantSpeed, _constantSpeed / 2).normalized * _constantSpeed;
        }

        rb.velocity = vel;
    }

    private void OnGUI()
    {
        float ballSpeed = rb.velocity.magnitude;
        string debugText = "Ball Speed = " + ballSpeed;

        GUI.TextArea(new Rect(Screen.width / 2 - 200, Screen.height - 200, 400, 110), debugText);
    }
}