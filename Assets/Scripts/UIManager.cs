using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text gameOverText;
    [SerializeField] private Text restartLevelInfoText;
    [SerializeField] private Image liveImage;
    [SerializeField] private Sprite[] livesSprites;
    
    private Player _player;
    void Start()
    {
        scoreText.text = "Score: " + 0;
        gameOverText.gameObject.SetActive(false);
        restartLevelInfoText.gameObject.SetActive(false);
    }

    public void UpdateScore(int playerScore)
    {
        scoreText.text = "Score: " + playerScore;
    }

    public void UpdateLivesCounter(int playerLives)
    {
        liveImage.sprite = livesSprites[playerLives];
        if (playerLives == 0)
        {
            GameOverSequence();
        }
    }
    
    void GameOverSequence()
    {
        gameOverText.gameObject.SetActive(true);
        restartLevelInfoText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickeringRoutine());
    }

    IEnumerator GameOverFlickeringRoutine()
    {
        while (true)
        {
            gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
            gameOverText.text = "GAME OVER";
        }

    }
}
