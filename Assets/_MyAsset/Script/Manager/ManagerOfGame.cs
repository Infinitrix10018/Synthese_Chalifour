using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ManagerOfGame : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _txtScore = default;
    [SerializeField] private TextMeshProUGUI _txtTime = default;

    private float _timeStart = default;
    private float _timeEnd = default;
    private int _score = default;
    private bool _messageEndBool = false;

    private UIEndManager _endManager = default;


    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        int nbrGestionJeu = FindObjectsOfType<ManagerOfGame>().Length;
        if (nbrGestionJeu > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        _endManager = FindObjectOfType<UIEndManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2 & !_messageEndBool)
        {
            _messageEndBool = true;
            //_endManager.Final();
        }
 

    }

    public void SetTimeStart()
    {
        _timeStart = Time.time;
    }

    public void SetTimeEnd()
    {
        _timeEnd = Time.time;
    }

    public void Setscore(int score)
    {
        _score = score;
    }

    public int GetScore()
    {
        Debug.Log(_score);
        return _score;
    }

    public float getFinalTime()
    { 
        return _timeEnd - _timeStart;    
    }

    public float getStartTime()
    {
        return _timeStart;
    }




}
