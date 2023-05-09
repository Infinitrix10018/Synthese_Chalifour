using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    [SerializeField] private float _speed = 2.0f;
    [SerializeField] private AudioClip _explosionSound = default;



    // Start is called before the first frame update
    void Start()
    {
        //AudioSource.PlayClipAtPoint(_explosionSound, Camera.main.transform.position, 0.3f);
        Destroy(gameObject, 1.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
