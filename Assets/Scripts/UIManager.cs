using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    // Start is called before the first frame update
    private Player _player;
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        scoreText.text = "Score: " + _player.GetScore();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + _player.GetScore();
    }
}
