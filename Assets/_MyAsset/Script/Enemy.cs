using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private GameObject _laserPreFab = default;
    [SerializeField] private GameObject _missilePreFab = default;
    [SerializeField] private float _fireRateM = 650f;
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] int _playerLives = 5;

    private float _canFire = -1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
