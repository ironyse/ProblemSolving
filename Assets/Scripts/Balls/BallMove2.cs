using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove2 : MonoBehaviour
{    
    private float _constantSpeed = 10f;    

    private void Update()
    {
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, cursorPosition, _constantSpeed * Time.deltaTime);
    }
}
