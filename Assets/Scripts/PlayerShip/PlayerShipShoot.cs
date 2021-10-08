using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipShoot : MonoBehaviour
{
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject laserPrefab;

    public float laserForce = 10f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject laser = Instantiate(laserPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * laserForce, ForceMode2D.Impulse);
    }
}
