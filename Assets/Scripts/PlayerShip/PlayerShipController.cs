using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour
{
    private Rigidbody2D rb;
    private CapsuleCollider2D capColl;

    [SerializeField] private float moveSpeed = 10f;

    Vector2 velocity = Vector2.zero;
    Vector2 mousePosition = Vector2.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capColl = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        velocity.x = Input.GetAxis("Horizontal");
        velocity.y = Input.GetAxis("Vertical");
        velocity = Vector2.ClampMagnitude(velocity * moveSpeed, moveSpeed);

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);        
    }

    private void FixedUpdate()
    {
        rb.velocity = velocity;
        Vector2 aimDirection = (mousePosition - rb.position).normalized;

        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;        
    }
}
