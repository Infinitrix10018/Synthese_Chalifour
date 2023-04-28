using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //[SerializeField] private GameObject _enemyPrefab = default;
    [SerializeField] private GameObject[] _listeEnemyPrefabs = default;
    [SerializeField] private GameObject _ObjectContainer = default;
    [SerializeField] private GameObject _miniBossContainer = default;
    [SerializeField] private GameObject _BossContainer = default;
    private bool _stopSpawning = false;

    void Start()
    {
        StartSpawming();
        //StartCoroutine(SpawnPURoutine());
    }

    /*
    IEnumerator SpawnPURoutine()
    {
        yield return new WaitForSeconds(3.0f);
        while (!_stopSpawning)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            int randomPU = Random.Range(0, _listePUsPrefabs.Length);
            GameObject newPU = Instantiate(_listePUsPrefabs[randomPU], posToSpawn, Quaternion.identity);
            newPU.transform.parent = _enemyContainer.transform;
            int randomTime = Random.Range(10, 15);
            yield return new WaitForSeconds(randomTime);

        }
    }
    */

    public void StartSpawming()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        //spawn enemy de base.
        yield return new WaitForSeconds(3.0f);
        while (!_stopSpawning)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_listeEnemyPrefabs[0], posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _listeEnemyPrefabs[0].transform;
            yield return new WaitForSeconds(5.0f);
        }

        //spawn mini boss.
        yield return new WaitForSeconds(120.0f);
        while (!_stopSpawning)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_listeEnemyPrefabs[1], posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _listeEnemyPrefabs[1].transform;
            yield return new WaitForSeconds(120.0f);
        }

        //spawn enemy de base.
        yield return new WaitForSeconds(300.0f);
        while (!_stopSpawning)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_listeEnemyPrefabs[2], posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _listeEnemyPrefabs[2].transform;
            yield return new WaitForSeconds(300.0f);
        }

    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
