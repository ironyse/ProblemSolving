using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    #region Singleton
    private static GameController _instance;
    public static GameController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameController>();
            }
            return _instance;
        }
    }
    #endregion

    [SerializeField] private Text scoreText;
    [SerializeField] private Text enemyDestroyedText;
    private int _score;
    private float _scoreTimer;

    public float scoreTimer;
    private int enemyShipDestroyed;

    private void Start()
    {
        _score = 0;
    }

    private void Update()
    {
        _scoreTimer -= Time.deltaTime;

        if (_scoreTimer <= 0f)
        {
            IncreaseScore();
            _scoreTimer = scoreTimer;
        }

        scoreText.text = $"Time Survived: {_score} Second(s)";
        enemyDestroyedText.text = $"Enemy Destoyed: {enemyShipDestroyed}";
        
    }

    public void IncreaseScore()
    {
        _score++;
    }

    public void DestroyEnemyShip()
    {
        enemyShipDestroyed++;
    }

}