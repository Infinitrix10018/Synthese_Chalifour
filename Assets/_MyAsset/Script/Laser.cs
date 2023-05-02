using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _speed = 25f;
    [SerializeField] private bool _enemy = true;

    void Update()
    {
        if (_enemy)
        {
            Debug.Log("test");
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
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
}
