using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private int _score = default;
    [SerializeField] private TextMeshProUGUI _txtVie = default;
    [SerializeField] private TextMeshProUGUI _txtPointage = default;
    [SerializeField] private TextMeshProUGUI _txtTemps = default;

    private Player _player;
    private SpawnManager _spawnManager;
    private bool _isTimeReduced = false;


    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = FindObjectOfType<SpawnManager>();
        _player = FindObjectOfType<Player>();
        UpdateLive(_player.getPlayerLive());
        UpdateScore(_score);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
    }

    public void UpdateLive(int vie)
    {
        _txtVie.text = "Vie : " + vie;
    }

    public void UpdateScore(int point)
    {
        _score += point;
        _txtPointage.text = "pointage : " + _score;

        if (_score % 5000 == 0 && _isTimeReduced == false)
        {
            _spawnManager.ReduceTime(_score);
            _isTimeReduced = true;
        }
        else if (_score % 5000 != 0 && _isTimeReduced == true)
        {
            _isTimeReduced = false;
        }
    }

    public void UpdateTime()
    {
        float temp = Time.time; //float temps = Time.time - _gestionJeu.GetTempsDepart();
        _txtTemps.text = "Temps : " + temp.ToString("f2");
    }

    public int GetScore()
    {
        return _score;
    }
}
