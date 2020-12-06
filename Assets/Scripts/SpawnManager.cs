using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]private GameObject _enemyPrefab;
    [SerializeField]private GameObject _enemyContainer;
    [SerializeField]private GameObject[] powerups;
    private bool _isAlive = false;

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }
    IEnumerator SpawnEnemyRoutine()
    {
        while (_isAlive == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-10f, 8f), 7, 0);
           GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator SpawnPowerupRoutine()
    {

        while (_isAlive == false)
        {         

            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            Instantiate(powerups[Random.Range(0,3)], posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(10, 20));

        }
    }

    public void OnPlayerDeath()
    {
        _isAlive = true;
    }
}
