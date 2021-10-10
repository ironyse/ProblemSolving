using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private bool canBounce;
    [SerializeField] private float maxDistance;

    Rigidbody2D rb;
    Animator anim;    
    Vector2 shotLocation;

    private void Awake()
    {
        shotLocation = transform.position;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float distance = Vector2.Distance(shotLocation, transform.position);
        if (distance >= maxDistance)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            rb.velocity = new Vector2(0f, 0f);
            anim.SetTrigger("IsHit");
            StartCoroutine(SetProjectActive(false));
        }

    }

    IEnumerator SetProjectActive(bool value)
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(value);
    }   
}
