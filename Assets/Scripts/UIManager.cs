﻿using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    // Start is called before the first frame update
    private Player _player;
    void Start()
    {
        scoreText.text = "Score: " + 0;
    }

    public void UpdateScore(int playerScore)
    {
        scoreText.text = "Score: " + playerScore;
    }
}