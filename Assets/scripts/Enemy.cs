using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] 
    private float speed = 4;

    void Start()
    {
        transform.position = new Vector3(Random.Range(-8.01f, 8.01f), 9.0f, 0);
    }

    void Update()
    {
        Transform transform1 = transform;
        Vector3 descendSpeed = Time.deltaTime * speed * Vector3.down;
        float randomModifyer = Random.Range(-8.01f, 8.01f);

        transform1.Translate(descendSpeed);


        if (transform1.position.y <= -6.18)
        {
            transform1.position = new Vector3(randomModifyer, 9.0f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        } else if (!other.CompareTag("Player")) return;
        Player player = other.transform.GetComponent<Player>();

        if (player)
        {
            player.Damage();
        }
        Destroy(gameObject);
    }
}