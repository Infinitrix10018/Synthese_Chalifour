using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _speed = 25f;
    [SerializeField] private bool _isEnemy = true;
    [SerializeField] private GameObject _prefabExplosion = default;

    private Player _player;



    private void Start()
    {
        _player= GetComponent<Player>();
    }

    void Update()
    {
        if (_isEnemy)
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
            if (transform.position.x < -15f)
            {
                Destroy(gameObject);
            }
        }
        else if(!_isEnemy)
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
        Debug.Log(collision.tag);
        if(collision.gameObject.name == "Player" && _isEnemy)
        {
            Debug.Log("attack laser enemy");
            _player.EmotionalDamage();
            Instantiate(_prefabExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }




}
