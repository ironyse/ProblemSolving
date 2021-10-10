using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (FindObjectOfType<GameController>())
            {
                GameController.Instance.IncreaseScore();
                BoxSpawner.Instance.BoxDestroyed();
                gameObject.SetActive(false);
            }
            
        }
    }
    
}
