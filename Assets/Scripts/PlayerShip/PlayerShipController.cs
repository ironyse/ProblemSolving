using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShipController : MonoBehaviour
{
    private Rigidbody2D rb;    

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private Text shieldText;

    Vector2 velocity = Vector2.zero;
    Vector2 mousePosition = Vector2.zero;

    private int shieldAmount;
    private int maxShieldAmount = 100;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
    }

    private void Update()
    {
        velocity.x = Input.GetAxis("Horizontal");
        velocity.y = Input.GetAxis("Vertical");
        velocity = Vector2.ClampMagnitude(velocity * moveSpeed, moveSpeed);

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        shieldText.text = $"Shield: {shieldAmount} %";
    }

    private void FixedUpdate()
    {
        rb.velocity = velocity;
        Vector2 aimDirection = (mousePosition - rb.position).normalized;

        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;        
    }

    public void IncreaseShield(int amount)
    {
        shieldAmount += amount;
        PlayerAudioController.Instance.PlayShieldUp();
        if (shieldAmount > 100)
        {
            shieldAmount = 100;
        }
    }

    public void DecreaseShield(int amount)
    {
        shieldAmount -= amount;
        if (shieldAmount < 0)
        {
            // player ship destroyed

            // game over            
        }
    }
}
