using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Serialize field
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] int _playerLives = 5;
    //Serialize field with object
    [SerializeField] private GameObject _laserPreFab = default;
    [SerializeField] private AudioClip _laserSound = default;

    //other variables
    private bool _canFire = true;

    //other variables with object
    private Animator _anime;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Mouvement();
       
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds( _fireRate );
        while (_canFire)
        {
            AudioSource.PlayClipAtPoint(_laserSound, Camera.main.transform.position, 0.2f);
            Instantiate(_laserPreFab, transform.position + new Vector3(0f, 0f, 0f), Quaternion.identity);
            yield return new WaitForSeconds(_fireRate);
        }
    }

    private void Mouvement()
    {
        float positionH = Input.GetAxis("Horizontal");
        float positionV = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(positionH, positionV, 0);
        transform.Translate(direction * Time.deltaTime * _speed);

        /*
        if (positionH < 0f)
        {
            _anime.SetBool("GoUp", true);
            _anime.SetBool("GoDown", false);
        }
        else if (positionH > 0f)
        {
            _anime.SetBool("GoUp", false);
            _anime.SetBool("GoDown", true);
        }
        else
        {
            _anime.SetBool("GoUp", false);
            _anime.SetBool("GoDown", false);
        }
        */

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.1f, 0.5f), 0);
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.9f, 8.9f), Mathf.Clamp(transform.position.y, -4.1f, 0.5f), 0);

        if (transform.position.x >= 8.9f)
        {
            transform.position = new Vector3(-8.9f, transform.position.y, 0);
        }
        else if (transform.position.x <= -8.9f)
        {
            transform.position = new Vector3(8.9f, transform.position.y, 0);
        }
    }


}
