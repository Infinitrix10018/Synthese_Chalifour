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




    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    public void UpdateTime()
    {
        float temp = Time.time; //float temps = Time.time - _gestionJeu.GetTempsDepart();
        _txtTemps.text = "Temps : " + temp.ToString("f2");
    }
}
