using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _speed = 25f;
    [SerializeField] private bool _enemy = true;
    [SerializeField] private GameObject _prefabExplosion = default;

    private Player _player;



    private void Start()
    {
        _player= GetComponent<Player>();
    }

    void Update()
    {
        if (_enemy)
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
            if (transform.position.x < -15f)
            {
                Destroy(gameObject);
            }
        }
        else if(!_enemy)
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
            if (transform.position.x > 15f)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && _enemy)
        {
            _player.EmotionalDamage();
            Instantiate(_prefabExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }




}
