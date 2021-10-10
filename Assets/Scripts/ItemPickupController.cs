using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Increase Player's Shield amount
            
            BoxSpawner.Instance.BoxDestroyed();
            gameObject.SetActive(false);
        }
    }
}
