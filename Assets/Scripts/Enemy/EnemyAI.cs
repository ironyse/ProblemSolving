using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 5f;
    public float shootDistance;
    public float retreatDistance;

    [SerializeField] private Transform player;

    Vector2 targetRandomPosition;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        targetRandomPosition = GetRandomPosition();
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance> shootDistance) {
            Chase();
            targetRandomPosition = GetRandomPosition();

        }  else if (distance > retreatDistance && distance < shootDistance) {            
            RandomMove();
            if (Vector2.Distance(transform.position, targetRandomPosition) < 0.1f)
            {
                targetRandomPosition = GetRandomPosition();
            }

        } else if (distance < retreatDistance) {            
            Retreat();
            targetRandomPosition = GetRandomPosition();

        }


    }

    private void FixedUpdate()
    {
        Vector2 aimDirection = (player.position - transform.position).normalized;

        //enemy's sprite are facing down
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg + 90f; 
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void RandomMove()
    {        
        transform.position = Vector2.MoveTowards(transform.position, targetRandomPosition, speed * Time.deltaTime);
    }

    private void Retreat()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
    }

    private Vector3 GetRandomPosition()
    {
        return transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * Random.Range(1f,2f);
    }

}
