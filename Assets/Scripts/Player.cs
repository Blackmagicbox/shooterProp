﻿using System.Collections;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    [SerializeField] private int lives = 3;
    [SerializeField] private float speed = 5.4f;
    [SerializeField] private float speedMultiplyer = 1.5f;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private GameObject tripleShotPrefab;

    private float canFire = -1f;

    private SpawnManager spawnManager;
    // Tripleshot powerup config
    [SerializeField] private bool isTripleShotActive;
    [SerializeField] private float tripleShotDuration = 5.0f;
    
    // Speedboost powerfup config
    [SerializeField] private bool isSpeedBoostActive;

    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        transform.position = new Vector3(0, 0, 0);
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
        lives--;
        if (lives < 1)
        {
            spawnManager.OnPlayersDeath();
            Destroy(this.gameObject);
        }
    }

    public void ActivateTripleShot()
    {
        isTripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(this.tripleShotDuration);
        isTripleShotActive = false;
    }
}