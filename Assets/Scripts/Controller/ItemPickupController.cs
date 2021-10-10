using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupController : MonoBehaviour
{
    private int shieldValue = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Increase Player's Shield amount
            PlayerShipController player = collision.GetComponent<PlayerShipController>();
            player.IncreaseShield(shieldValue);

            BoxSpawner.Instance.BoxDestroyed();
            gameObject.SetActive(false);
        }
    }
}
