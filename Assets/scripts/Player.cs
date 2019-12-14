using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int lives = 3;

    [SerializeField] 
    private float speed = 5.4f;

    [SerializeField]
    private float fireRate = 0.5f;

    [SerializeField] 
    private GameObject laserPrefab;

    private float _canFire = -1f;
    private SpawnManager _spawnManager;

    void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        MovePlayer();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            Shoot();
        }

    }

    private void Shoot()
    {
        _canFire = Time.time + fireRate;
        Instantiate(laserPrefab, transform.position + new Vector3( 0, 0.8f, 0), Quaternion.identity);
    }

    private void MovePlayer()
    {
        // Move the player
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        var direction = new Vector3(horizontalInput, verticalInput, 0);

        // Bounding box
        var currentPostion = transform.position;

        currentPostion = new Vector3(currentPostion.x, Mathf.Clamp(currentPostion.y, -4.87f, 0), 0);


        if (transform.position.x >= 10.19)
        {
            currentPostion = new Vector3(-10.19f, currentPostion.y, 0);
        }
        else if (transform.position.x <= -10.19)
        {
            currentPostion = new Vector3(10.19f, currentPostion.y, 0);
        }

        transform.position = currentPostion;


        transform.Translate(Time.deltaTime * speed * direction);
    }

    public void Damage()
    {
        lives--;
        if (lives < 1)
        {
            _spawnManager.OnPlayersDeath();
            Destroy(this.gameObject);
            
        }
    }
}