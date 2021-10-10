using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipShoot : MonoBehaviour
{
    [SerializeField] private Transform firepoint;

    public string projectileTag = "Laser";
    public float projectileForce = 10f;
    public int projectileDamage = 1;
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
            PlayerAudioController.Instance.PlayShootAudio();
        }
    }

    private void Shoot()
    {
        GameObject laser = objPooler.SpawnFromPool(projectileTag, firepoint.position, firepoint.rotation);
        Projectile projectile = laser.GetComponent<Projectile>();
        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();

        projectile.excludeTargetTag = "Player";
        projectile.projectileDamage = projectileDamage;
        rb.AddForce(firepoint.up * projectileForce, ForceMode2D.Impulse);
    }
}
