using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEndManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _txtPointage = default;
    [SerializeField] private TextMeshProUGUI _txtTemps = default;

    private int _score = default;
    private float _time = default;

    private ManagerOfGame _managerOfGame = default; 


    // Start is called before the first frame update
    void Awake()
    {
        //Final();
    }

    private void Start()
    {
        _score = _managerOfGame.GetScore();
        _time = _managerOfGame.getFinalTime();

        Debug.Log(_score + " " + _time);

        _txtPointage.text = _score.ToString();
        _txtTemps.text = _time.ToString("f2");
    }

    /*
    public void Final()
    {
        _txtPointage.text = _managerOfGame.GetScore().ToString();
        _txtTemps.text = _managerOfGame.getFinalTime().ToString("f2");

    }
    */




}
