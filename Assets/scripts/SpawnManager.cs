using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] 
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject enemyContainer;
    [SerializeField]
    private float spawRate = 5.0f;

    private bool _shouldSpaw = true;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
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

    public void OnPlayersDeath()
    {
        _shouldSpaw = false;
    }

}