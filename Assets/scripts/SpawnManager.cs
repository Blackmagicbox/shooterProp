using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] 
    private GameObject enemyPrefab;
    
    [SerializeField] 
    private GameObject tripleShotPowerupPrefab;
    
    [SerializeField]
    private GameObject enemyContainer;
    
    [SerializeField]
    private float spawRate = 5.0f;
    
    [SerializeField]
    private float powerupMinSpawRate = 5.0f;
    
    [SerializeField]
    private float powerupMaxSpawRate = 5.0f;

    private bool _shouldSpaw = true;

    private void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (_shouldSpaw)
        {
            GameObject newEnemy = Instantiate(
                enemyPrefab,
                transform.position + new Vector3(Random.Range(-8.01f, 8.01f), 9.0f, 0),
                Quaternion.identity
            );
            newEnemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(spawRate);
        }
    }
    
    IEnumerator SpawnPowerUpRoutine()
    {
        /* Because the powerup destroys itself when out of the screen or when the player picks it
         We don't need a container to handle it. */
        
        while (_shouldSpaw)
        {
            
            Vector3 spanwPosition = transform.position + new Vector3(Random.Range(-8.01f, 8.01f), 9.0f, 0);
                Instantiate(
                    tripleShotPowerupPrefab,
                    spanwPosition,
                    Quaternion.identity
                );
            yield return new WaitForSeconds(Random.Range(powerupMinSpawRate, powerupMaxSpawRate));
        }

    }

    public void OnPlayersDeath()
    {
        _shouldSpaw = false;
    }

}