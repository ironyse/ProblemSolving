using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;

    private BoxCollider2D bgCollider;
    private Rigidbody2D bgRig;
    private float height;

    private void Start()
    {
        bgCollider = GetComponent<BoxCollider2D>();
        bgRig = GetComponent<Rigidbody2D>();
        height = bgCollider.size.y;
        bgCollider.enabled = false;
    }

    private void Update()
    {
        bgRig.velocity = new Vector2(0, -scrollSpeed);

        if (transform.position.y < -height)
        {
            Vector2 resetPosition = new Vector2(0, height * 2f);
            transform.position = (Vector2)transform.position + resetPosition;
        }
    }
}
