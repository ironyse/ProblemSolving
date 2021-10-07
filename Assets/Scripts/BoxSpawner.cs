using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private int cellSizeX = 9;
    [SerializeField] private int cellSizeY = 5;

    [SerializeField] private Transform[] boxes;

    public LayerMask objectsLayer;

    //private Transform[] _boxesPool;
    private float offset = 0.5f;
    private int minBoxes = 4;
    private int maxBoxes = 9;

    private void Start()
    {
        int rand = Random.Range(minBoxes, maxBoxes);

        for (int i = 0; i < rand; i++)
        {
            GenerateBox();
        }
    }

    private void GenerateBox()
    {
        int randIndex = Random.Range(0, boxes.Length);
        Transform box = boxes[randIndex];

        float xPosition = Random.Range(-cellSizeX, cellSizeX) + offset;
        float yPosition = Random.Range(-cellSizeY, cellSizeY) + offset;
        Vector2 point = new Vector2(xPosition, yPosition);

        Collider2D[] objects = Physics2D.OverlapBoxAll(point, new Vector2(1f, 1f), 0f, objectsLayer);

        if (objects.Length > 0)
        {
            GenerateBox();
        }
        else
        {
            Instantiate(box.gameObject, point, Quaternion.identity);
        }

    }
}