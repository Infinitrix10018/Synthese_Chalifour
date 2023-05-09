using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //[SerializeField] private GameObject _enemyPrefab = default;
    [SerializeField] private GameObject[] _listeEnemyPrefabs = default;
    [SerializeField] private GameObject _ObjectContainer = default;
    private bool _stopSpawning = false;
    private float _timerBoss = 90f;
    private float _timerMiniBoss = 30f;
    public float _timerEnemy = 3f;
    private bool _bossTime = false;

    void Start()
    {
        StartSpawming();
    }

    public void StartSpawming()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnBossRoutine());
        StartCoroutine(SpawnMiniBossRoutine());
        Debug.Log("d�but spawns");
        Debug.Log(_listeEnemyPrefabs.Length);
    }

    IEnumerator SpawnEnemyRoutine()
    {
        //spawn enemy de base.
        yield return new WaitForSeconds(1111f);
        while (!_stopSpawning)
        {
            Vector3 posToSpawn = new Vector3( 15, Random.Range(-4f, 4f), 0);
            GameObject newEnemy = Instantiate(_listeEnemyPrefabs[0], posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(_timerEnemy); 
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
            yield return new WaitForSeconds(_timerMiniBoss);
        }
    }

    IEnumerator SpawnBossRoutine()
    {
        //spawn enemy de base.
        yield return new WaitForSeconds(1f);
        while (!_stopSpawning)
        {
            Vector3 posToSpawn = new Vector3(15, Random.Range(-4f, 4f), 0);
            GameObject newEnemy = Instantiate(_listeEnemyPrefabs[2], posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(_timerBoss);
        }

    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }

    public void ReduceTime()
    {
        // Le taux de spawn est 4/5 du pr�c�dent
        _timerBoss *= 0.8f;
        _timerMiniBoss *= 0.8f;
        _timerEnemy *= 0.8f;
    }


}
