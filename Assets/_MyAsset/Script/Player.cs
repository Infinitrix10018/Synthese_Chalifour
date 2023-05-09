using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private GameObject _prefabAttack1 = default;
    [SerializeField] private GameObject _prefabAttack2 = default;
    [SerializeField] private float _attack1Time = 0.2f;
    [SerializeField] private float _attack2Time = 1f;
    [SerializeField] private int _playerLife = 5;

    private float _canAttack1 = -1f;
    private float _canAttack2 = 0.25f;

    private UIManager _UIManager = default;


    // Start is called before the first frame update
    void Start()
    {
        _UIManager = FindObjectOfType<UIManager>();
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

        /*
        if (horizontalInput < 0)
        {
            _anim.SetBool("Turn_Left", true);
            _anim.SetBool("Turn_Right", false);
        }
        else if (horizontalInput > 0)
        {
            _anim.SetBool("Turn_Left", false);
            _anim.SetBool("Turn_Right", true);
        }
        else
        {
            _anim.SetBool("Turn_Left", false);
            _anim.SetBool("Turn_Right", false);
        }
        */
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
        }
    }

    public void EmotionalDamage()
    {
        _playerLife--;
        _UIManager.UpdateLive(_playerLife);
        if (_playerLife <= 0)
        {
            Destroy(this.gameObject);
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
