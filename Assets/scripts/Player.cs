using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    [SerializeField] 
    private float speed = 5.4f;
    
    [SerializeField] 
    private GameObject laserPrefab;

    [SerializeField]
    private float fireRate = 0.5f;

    private float _canFilre = -1f;


    // Start is called before the first frame update
    void Start()
    {
        // Take the current position = new position  (0,0,0)
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFilre)
        {
            Shoot();
        }

    }

    private void Shoot()
    {
        _canFilre = Time.time + fireRate;
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
}