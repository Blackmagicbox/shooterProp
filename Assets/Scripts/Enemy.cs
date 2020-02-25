using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 4;
    private Player _player;
    private Animator _anim;

    void Start()
    {
        transform.position = new Vector3(Random.Range(-8.01f, 8.01f), 9.0f, 0);
        _player = GameObject.Find("Player").GetComponent<Player>();
        if (_player == null)
        {
            Debug.LogError("The player is null");
        }

        _anim = GetComponent<Animator>();
        if (_anim == null)
        {
            Debug.LogError("The animator object is null");
        }
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
            // Find the player and call the IncrementScore function to increment the points.
            if (_player != null)
            {
                _player.IncrementScore(10);
            }
            Destroy(other.gameObject);
            _anim.SetTrigger("OnEnemyDestruction");
            Destroy(gameObject, 2.0f);
        }
        else if (other.CompareTag("Player"))
        {
            Player _player = other.transform.GetComponent<Player>();

            if (!_player) return;
            _player.Damage();
            _anim.SetTrigger("OnEnemyDestruction");
            Destroy(gameObject, 2.0f);
        };

    }
}