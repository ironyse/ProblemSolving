using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private int cellSizeX = 9;
    [SerializeField] private int cellSizeY = 5;    
    [SerializeField] private float spawnDelay = 3f;

    #region Singleton
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
    #endregion
    
    ObjectPooler objPooler;

    public LayerMask objectsLayer;
    public string boxTag;
    private float offset = 0.5f;
    private int minAmount = 4;
    private int maxAmount = 8;

    public bool canRespawn = true;

    private void Start()
    {
        objPooler = ObjectPooler.Instance;
        int rand = Random.Range(minAmount, maxAmount);

        for (int i = 0; i < rand; i++)
        {
            GenerateBox();
        }
    }

    public void GenerateBox()
    {        
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
            objPooler.SpawnFromPool(boxTag, point, Quaternion.identity);            
        }

    }

    public void BoxDestroyed()
    {
        if (!canRespawn) return; 

        StartCoroutine(SpawnAfter(spawnDelay));
    }

    private IEnumerator SpawnAfter(float second)
    {
        yield return new WaitForSeconds(second);
        GenerateBox();
    }
}