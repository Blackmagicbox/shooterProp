using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    [SerializeField] private int lives = 3;
    [SerializeField] private float speed = 5.4f;
    [SerializeField] private float speedMultiplyer = 1.5f;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private GameObject tripleShotPrefab;
    private int score = 0;

    private float canFire = -1f;

    private SpawnManager spawnManager;

    // Cool down for all powerups
    [SerializeField] private float tripleShotCooldDownTime = 5.0f;
    [SerializeField] private float speedBoostCooldDownTime = 5.0f;

    // Tripleshot powerup config
    [SerializeField] private bool isTripleShotActive;

    // Speedboost powerup config
    [SerializeField] private bool isSpeedBoostActive;

    // Shield powerup config
    [SerializeField] private bool isShieldActive;
    [SerializeField] private GameObject shieldVisualizer;

    // Ui Manager
    private UIManager _uiManager;

    void Start()
    {

        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        transform.position = new Vector3(0, 0, 0);
        shieldVisualizer.SetActive(false);
    }

    void Update()
    {
        MovePlayer();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canFire)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        canFire = Time.time + fireRate;
        GameObject fire = laserPrefab;
        Vector3 pos = transform.position + new Vector3(0, 1.05f, 0);

        if (isTripleShotActive)
        {
            fire = tripleShotPrefab;
            pos = transform.position + new Vector3(0, 0, 0);
        }

        Instantiate(fire, pos, Quaternion.identity);
    }

    private void MovePlayer()
    {
        // Move the player
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        var direction = new Vector3(horizontalInput, verticalInput, 0);

        // Bounding box
        var currentPostion = transform.position;

        currentPostion = new Vector3(currentPostion.x, Mathf.Clamp(currentPostion.y, -2.91f, 0), 0);


        if (transform.position.x >= 9.76)
        {
            currentPostion = new Vector3(-9.76f, currentPostion.y, 0);
        }
        else if (transform.position.x <= -9.76)
        {
            currentPostion = new Vector3(9.76f, currentPostion.y, 0);
        }

        transform.position = currentPostion;

        if (isSpeedBoostActive)
        {
            transform.Translate(Time.deltaTime * (speed * speedMultiplyer) * direction);
        }
        else
        {
            transform.Translate(Time.deltaTime * speed * direction);
        }
    }

    public void Damage()
    {
        if (isShieldActive)
        {
            isShieldActive = false;
            shieldVisualizer.SetActive(false);
            return;
        }

        lives--;
        if (lives >= 1) return;
        spawnManager.OnPlayersDeath();
        Destroy(this.gameObject);
    }

    public void ActivateTripleShot()
    {
        isTripleShotActive = true;
        StartCoroutine(TripleShotCooldownRoutine());
    }

    IEnumerator TripleShotCooldownRoutine()
    {
        yield return new WaitForSeconds(tripleShotCooldDownTime);
        isTripleShotActive = false;
    }

    public void ActivateSpeedBoost()
    {
        isSpeedBoostActive = true;
        StartCoroutine(SpeedBoostCooldownRoutine());
    }

    IEnumerator SpeedBoostCooldownRoutine()
    {
        yield return new WaitForSeconds(speedBoostCooldDownTime);
        isSpeedBoostActive = false;
    }

    public void ActivateShield()
    {
        isShieldActive = true;
        shieldVisualizer.SetActive(true);
    }

    public void IncrementScore(int points)
    {
        score += points;
        _uiManager.UpdateScore(score);
    }
}
    