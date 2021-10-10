using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove1 : MonoBehaviour
{
    private Rigidbody2D rb;
    private float _constantSpeed = 10f;

    Vector2 velocity = Vector2.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        velocity.x = Input.GetAxis("Horizontal");
        velocity.y = Input.GetAxis("Vertical");
        velocity = Vector2.ClampMagnitude(velocity * _constantSpeed, _constantSpeed);

        rb.velocity = velocity;
    }
}
