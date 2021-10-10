using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private int cellSizeX = 9;
    [SerializeField] private int cellSizeY = 5;
    [SerializeField] private Transform[] boxes;
    [SerializeField] private float spawnDelay = 3f;

    private static BoxSpawner _instance;
    public static BoxSpawner Instance
    {
        get
        {
            if (_instance == null) {
                _instance = FindObjectOfType<BoxSpawner>();
            }
            return _instance;
        }
    }
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

    public void GenerateBox()
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

    public void BoxDestroyed()
    {
        StartCoroutine(SpawnAfter(spawnDelay));
    }

    private IEnumerator SpawnAfter(float second)
    {
        yield return new WaitForSeconds(second);
        GenerateBox();
    }
}