using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] 
    private float speed = 4;

    void Start()
    {
        transform.position = new Vector3(0, 5.95f, 0);
    }

    void Update()
    {
        Transform transform1 = transform;
        Vector3 descendSpeed = Time.deltaTime * speed * Vector3.down;
        float randomModifyer = Random.Range(-10f, 10f);

        transform1.Translate(descendSpeed);


        if (transform1.position.y <= -6.17)
        {
            transform1.position = new Vector3(randomModifyer, 5.95f, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
        } else if (other.CompareTag("Player"))
        {
            Player player = other.transform.GetComponent<Player>();

            if (player)
            {
                player.Damage();
            }
        }
        Destroy(this.gameObject);
    }
}