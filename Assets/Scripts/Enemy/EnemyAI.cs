using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 5f;
    public float shootDistance;
    public float retreatDistance;
    public float offsetDistance;

    [SerializeField] private Transform player;
    [SerializeField] private Transform firepoint;

    public string projectileTag = "Laser";
    public float laserForce = 0.5f;
    public int projectileDamage = 25;
    public float shootDelay;
    private float _shootTimer;
    

    ObjectPooler objPooler;
    Vector2 targetRandomPosition;

    private void Start()
    {
        objPooler = ObjectPooler.Instance;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        targetRandomPosition = GetRandomPosition();
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        _shootTimer -= Time.deltaTime;

        if (distance> shootDistance) {
            Chase();            

        }  else if (distance > retreatDistance  && distance < shootDistance) {            
            RandomMove();            

        } else if (distance < retreatDistance) {            
            Retreat();
        }


    }

    private void FixedUpdate()
    {
        Vector2 aimDirection = (player.position - transform.position).normalized;

        //+90f becasue enemy's sprite are facing down
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg + 90f; 
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        targetRandomPosition = GetRandomPosition();
    }

    private void RandomMove()
    {
        Shoot();
        transform.position = Vector2.MoveTowards(transform.position, targetRandomPosition, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetRandomPosition) < 0.1f)
        {
            targetRandomPosition = GetRandomPosition();
        }
    }

    private void Retreat()
    {
        Shoot();
        transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        targetRandomPosition = GetRandomPosition();
    }

    private void Shoot()
    {
        if (_shootTimer <= 0f)
        {
            GameObject laser = objPooler.SpawnFromPool(projectileTag, firepoint.position, firepoint.rotation);
            Projectile projectile = laser.GetComponent<Projectile>();
            Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();

            projectile.excludeTargetTag = "Enemy";
            projectile.projectileDamage = projectileDamage;
            rb.AddForce(firepoint.up * laserForce, ForceMode2D.Impulse);

            _shootTimer = shootDelay;
        }
        
    }

    private Vector3 GetRandomPosition()
    {
        return transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * Random.Range(1f,2f);
    }

}
