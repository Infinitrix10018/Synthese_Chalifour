using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Serialize field
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _fireRate = 1.5f;
    [SerializeField] int _EnemyLives = 1; // boss = 10, mini boss = 5 enemy = 1
    [SerializeField] int _idEnemy = 2; // 0 = boss, 1 = mini boss et 2 = ennemy par default
    //Serialize field with object
    [SerializeField] private GameObject _laserPreFab = default;
    [SerializeField] private AudioClip _laserSound = default;
    [SerializeField] private GameObject _prefabExplosion = default;

    //other variables
    private float _canFire = -1f;
    private bool _exist = true; //the while need a variable to work
    private int _point = 0;

    //other variables with object
    private Animator _anime;
    private Player _player;
    private UIManager _UIManager = default;
    private SpawnManager _spawnManager = default;



    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = FindObjectOfType<SpawnManager>();
        _player = FindObjectOfType<Player>();
        _UIManager = FindObjectOfType<UIManager>();
        PointPerEnemy();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EnemyAttack();
        MouvementEnemy();
    }

    private void MouvementEnemy()
    {
        switch(_idEnemy)
        {
            case 0:
                transform.Translate(Vector3.left * Time.deltaTime * _speed);
                transform.position = new Vector3( Mathf.Clamp(transform.position.x, 5f, 17f), transform.position.y, 0);
                break;

            case 1:
                transform.Translate(Vector3.left * Time.deltaTime * _speed);
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, 2f, 17f), transform.position.y, 0);
                break;

            case 2:
                transform.Translate(Vector3.left * Time.deltaTime * _speed);

            break;
        }

        if (transform.position.x < -15f)
        {
            float _randomX = Random.Range(-4f, 4f);

            transform.position = new Vector3(15f, _randomX, 0f);
        }
    }

    private void EnemyAttack()
    {

        if (_idEnemy == 0) 
        {
            if(Time.time > _canFire)
            {
                _canFire = Time.time + _fireRate;
                Instantiate(_laserPreFab, transform.position + new Vector3(-5f, 0f, 0f), Quaternion.identity);
            }
        }
        else if (_idEnemy == 1)
        {
            if (Time.time > _canFire)
            {
                _canFire = Time.time + _fireRate;
                Instantiate(_laserPreFab, transform.position + new Vector3(-5f, 3f, 0f), Quaternion.identity);
            }
        }

    }

    IEnumerator BossAttack()
    {
        yield return new WaitForSeconds(1f);
        while( _exist == true )
        {
            Instantiate(_laserPreFab, transform.position + new Vector3(0f, 0f, 0f), Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DamageEnemy(1);
            _player.EmotionalDamage();
            //Debug.Log("enemy hit!");
            BigEmotionalDamage();
        }
        else if (collision.tag == "Laser2")
        {
            DamageEnemy(5);
        }
        else if (collision.tag == "Laser")
        {
            Destroy(collision.gameObject);
            DamageEnemy(1);
        }
    }

    private void BigEmotionalDamage()
    {
        Instantiate(_prefabExplosion, transform.position, Quaternion.identity);
        //Destroy(gameObject);
    }

    private void PointPerEnemy()
    {
        switch(_idEnemy)
        {
            case 0: 
                _point = 15000; Debug.Log("boss");
                _EnemyLives = 15;
                break;
            case 1:
                _point = 5000;
                _EnemyLives = 5;
                break;
            case 2:
                _point = 100;
                _EnemyLives = 1;
                break;
        }
    }

    private void DamageEnemy(int damage)
    {
        _EnemyLives -= damage;

        if (_idEnemy == 0 || _idEnemy == 1)
        {
            //Debug.Log(_EnemyLives);
        }

        if (_EnemyLives <= 0)
        {
            BigEmotionalDamage();
            _UIManager.UpdateScore(_point);  
            Destroy(gameObject);
        }
    }




}
