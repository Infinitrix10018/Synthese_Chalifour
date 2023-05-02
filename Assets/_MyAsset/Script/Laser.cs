using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _speed = 25f;
    [SerializeField] private bool _enemy = false;

    void Update()
    {
        if (_enemy)
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
            if (transform.position.x > 9f)
            {
                Destroy(gameObject);
            }
        }
        else if(!_enemy)
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
            if (transform.position.x > 9f)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
