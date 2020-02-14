using System;
using UnityEditor;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    // 0 = tripleShot; 1 = speed; 2 = shield;
    [SerializeField] private int powerUpId;
    [SerializeField] private float speed = 3.0f;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.down);
        if (transform.position.y < -6.07f) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Player player = other.transform.GetComponent<Player>();

        if (!player) return;
        switch (powerUpId)
        {
            case 0:
                player.ActivateTripleShot();
                break;
            case 1:
                Debug.Log("Speedup");
                break;
            case 2:
                Debug.Log("Shield");
                break;
        }
        Destroy(gameObject);
    }
}