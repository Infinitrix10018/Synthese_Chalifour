using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private GameObject _prefabAttack1 = default;
    [SerializeField] private GameObject _prefabAttack2 = default;
    [SerializeField] private float _attack1Time = 0.2f;
    [SerializeField] private float _attack2Time = 2f;
    [SerializeField] private int _playerLife = 5;
    [SerializeField] private GameObject _prefabAnimAttack2 = default;

    private float _canAttack1 = -1f;
    private float _canAttack2 = 0.25f;

    private UIManager _UIManager = default;
    private SpawnManager _spawnManager = default;
    private Animator _anim;
    private ManagerOfScene _managerOfScene = default;
    private ManagerOfGame _managerOfGame = default;


    // Start is called before the first frame update
    void Start()
    {
        _UIManager = FindObjectOfType<UIManager>();
        _spawnManager= FindObjectOfType<SpawnManager>();
        _anim = GetComponent<Animator>();
        _managerOfScene= FindObjectOfType<ManagerOfScene>();
        _managerOfGame = FindObjectOfType<ManagerOfGame>();
    }

    private void Update()
    {
        Move();
        Fire();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0f);
        transform.Translate(direction * Time.deltaTime * _speed);

        
        if (verticalInput < 0)
        {
            _anim.SetBool("GoDown", true);
            _anim.SetBool("GoUp", false);
        }
        else if (verticalInput > 0)
        {
            _anim.SetBool("GoDown", false);
            _anim.SetBool("GoUp", true);
        }
        else
        {
            _anim.SetBool("GoDown", false);
            _anim.SetBool("GoUp", false);
        }
        
        //Gérer la zone verticale
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.8f, 0f), transform.position.y, 0f);

        //Gérer dépassement horizontaux
        if (transform.position.y >= 5.3)
        {
            transform.position = new Vector3(transform.position.x, -5.3f, 0f);
        }
        else if (transform.position.y <= -5.3)
        {
            transform.position = new Vector3(transform.position.x, 5.3f, 0f);
        }
    }

    private void Fire()
    {
        if (Input.GetAxis("Fire1") == 1 && Time.time > _canAttack1)
        {
            _canAttack1 = Time.time + _attack1Time;

            Instantiate(_prefabAttack1, (transform.position + new Vector3(2.2f, -0.3f, 0f)), Quaternion.identity);
        }

        if (Input.GetAxis("Fire2") == 1 && Time.time > _canAttack2)
        {
            _canAttack2 = Time.time + _attack2Time;

            Instantiate(_prefabAttack2, (transform.position + new Vector3(2.5f, -0.25f, 0f)), Quaternion.identity);
            Instantiate(_prefabAnimAttack2, (transform.position + new Vector3(2.6f, -0.25f, 0f)), Quaternion.identity);
        }
    }

    public void EmotionalDamage()
    {
        _playerLife--;
        _UIManager.UpdateLive(_playerLife);
        if (_playerLife <= 0)
        {
            Destroy(gameObject);
            _spawnManager.OnPlayerDeath();
            _managerOfScene.SceneEnd();
            _UIManager.PlayerDeath();
            _managerOfGame.SetTimeEnd();
        }
    }

    public int getPlayerLive()
    {
        return _playerLife;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "LaserEnemy")
        {
            Debug.Log("attaque d'énemi contre le joueur");
            EmotionalDamage();
        }
    }





}
