using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
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

    [SerializeField] private Text scoreText;
    private int _score;


    private void Start()
    {
        _score = 0;
    }

    private void Update()
    {
        scoreText.text = $"Score: {_score}";
    }

    public void IncreaseScore()
    {
        _score++;
    }

}