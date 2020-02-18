using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Image liveImage;
    [SerializeField] private Sprite[] livesSprites;
    
    private Player _player;
    void Start()
    {
        scoreText.text = "Score: " + 0;
    }

    public void UpdateScore(int playerScore)
    {
        scoreText.text = "Score: " + playerScore;
    }

    public void UpdateLivesCounter(int playerLives)
    {
        liveImage.sprite = livesSprites[playerLives];
    }
}
