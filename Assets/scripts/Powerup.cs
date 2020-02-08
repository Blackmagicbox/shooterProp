﻿using System;
using UnityEditor;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate( speed * Time.deltaTime * Vector3.down);

        if (transform.position.y < -6.07f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        
        Player player = other.transform.GetComponent<Player>();
        if (player)
        {
            player.IsTripleShotActive = true;
                
        }

    }
}
