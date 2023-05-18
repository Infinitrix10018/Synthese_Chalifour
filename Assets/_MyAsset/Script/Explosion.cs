using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    [SerializeField] private AudioClip _explosionSound = default;
    [SerializeField] private float _time = 0f;



    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(_explosionSound, Camera.main.transform.position, 0.15f);
        Destroy(gameObject, _time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
