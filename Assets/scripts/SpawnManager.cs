using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
//    [SerializeField]
//    private int maxEnemyNumber = 5;
    [SerializeField]
    private GameObject enemyPrefab;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }


    IEnumerator SpawnRoutine()
    {
//        int currentEnemyCount = 0;
//        while (currentEnemyCount <= maxEnemyNumber)
        while (true)
        {
//            currentEnemyCount++;
            Instantiate(enemyPrefab, transform.position + new Vector3(Random.Range(-10f, 10f), 5.94f, 0),
                Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }

}