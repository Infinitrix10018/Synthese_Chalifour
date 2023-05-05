using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //[SerializeField] private GameObject _enemyPrefab = default;
    [SerializeField] private GameObject[] _listeEnemyPrefabs = default;
    [SerializeField] private GameObject _ObjectContainer = default;
    private bool _stopSpawning = false;
    private float _timerBoss = 300f;
    private float _timerMiniBoss = 120f;
    public float _timerEnemy = 3f;

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
        StartCoroutine(SpawnBossRoutine());
        StartCoroutine(SpawnMiniBossRoutine());
        Debug.Log("début spawns");
        Debug.Log(_listeEnemyPrefabs.Length);
    }

    IEnumerator SpawnEnemyRoutine()
    {
        //spawn enemy de base.
        yield return new WaitForSeconds(_timerEnemy);
        while (!_stopSpawning)
        {
            Vector3 posToSpawn = new Vector3( 15, Random.Range(-4f, 4f), 0);
            GameObject newEnemy = Instantiate(_listeEnemyPrefabs[0], posToSpawn, Quaternion.identity);
            //newEnemy.transform.parent = _listeEnemyPrefabs[0].transform;
            yield return new WaitForSeconds(_timerEnemy);
            //Debug.Log("Enemy de base");
        }
    }

    IEnumerator SpawnMiniBossRoutine()
    {
        //spawn mini boss.
        yield return new WaitForSeconds(_timerMiniBoss);
        while (!_stopSpawning)
        {
            Vector3 posToSpawn = new Vector3(15, Random.Range(-4f, 4f), 0);
            GameObject newEnemy = Instantiate(_listeEnemyPrefabs[1], posToSpawn, Quaternion.identity);
            //newEnemy.transform.parent = _listeEnemyPrefabs[1].transform;
            _timerMiniBoss *= 0.9f;
            yield return new WaitForSeconds(_timerMiniBoss);
            //Debug.Log("mini boss");
        }
    }

    IEnumerator SpawnBossRoutine()
    {
        //spawn enemy de base.
        yield return new WaitForSeconds(_timerBoss);
        while (!_stopSpawning)
        {
            Vector3 posToSpawn = new Vector3(15, Random.Range(-4f, 4f), 0);
            GameObject newEnemy = Instantiate(_listeEnemyPrefabs[2], posToSpawn, Quaternion.identity);
            _timerBoss *= 0.9f;
            //newEnemy.transform.parent = _listeEnemyPrefabs[2].transform;
            yield return new WaitForSeconds(_timerBoss);
            //Debug.Log("boss");
        }

    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
