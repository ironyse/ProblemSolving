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
    private float _shieldDecayTimer;

    public int shieldDecayAmount;
    public float shieldDecayTime;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
    }

    private void Update()
    {
        if (GameController.Instance.IsGameOver) return;

        velocity.x = Input.GetAxis("Horizontal");
        velocity.y = Input.GetAxis("Vertical");
        velocity = Vector2.ClampMagnitude(velocity * moveSpeed, moveSpeed);

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        shieldText.text = $"Shield: {shieldAmount} %";

        _shieldDecayTimer -= Time.deltaTime;
        if (_shieldDecayTimer <= 0f && shieldAmount > shieldDecayAmount)
        {
            DecreaseShield(shieldDecayAmount);
            _shieldDecayTimer = shieldDecayTime;
        }

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
        if (shieldAmount > maxShieldAmount)
        {
            shieldAmount = maxShieldAmount;
        }
    }

    public void DecreaseShield(int amount)
    {
        shieldAmount -= amount;
        if (shieldAmount < 0)
        {
            shieldAmount = 0;
            shieldText.text = $"Shield: {shieldAmount} %";

            // player ship destroyed
            gameObject.SetActive(false);

            // game over            
            GameController.Instance.GameOver();
        }
    }
}
