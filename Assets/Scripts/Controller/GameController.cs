﻿using UnityEngine;
using UnityEngine.SceneManagement;
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

    private int enemyShipDestroyed;
    public float scoreTimer;

    public AudioSource bgm;
    public GameObject gameOverPanel;

    public bool IsGameOver { get; private set; }

    private void Start()
    {
        _score = 0;
        IsGameOver = false;
        gameOverPanel.SetActive(false);
    }

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1)
        {
            Destroy(bgm.gameObject);
        }

        DontDestroyOnLoad(bgm.gameObject);
    }

    private void Update()
    {
        if (IsGameOver) { 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RestartGame();
            }

            return;
        }

        _scoreTimer -= Time.deltaTime;

        if (_scoreTimer <= 0f)
        {
            IncreaseScore();
            _scoreTimer = scoreTimer;
        }

        scoreText.text = $"Time Survived: {_score} Second(s)";
        enemyDestroyedText.text = $"Enemy Destoyed: {enemyShipDestroyed}";
        
    }

    public void GameOver()
    {
        if (!IsGameOver)
        {
            gameOverPanel.SetActive(true);
            IsGameOver = true;
        }
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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