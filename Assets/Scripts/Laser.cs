using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private GameObject laserExplosion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject explosion = Instantiate(laserExplosion, transform.position, Quaternion.identity);
        Destroy(explosion, 2f);
        Destroy(gameObject);
    }
    
}
