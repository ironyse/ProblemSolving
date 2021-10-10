using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipShoot : MonoBehaviour
{
    [SerializeField] private Transform firepoint;

    public string projectileTag = "Laser";
    public float projectileForce = 10f;
    ObjectPooler objPooler;

    private void Start()
    {
        objPooler = ObjectPooler.Instance;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject laser = objPooler.SpawnFromPool(projectileTag, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * projectileForce, ForceMode2D.Impulse);
    }
}
