using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStartManager : MonoBehaviour
{
    [SerializeField] GameObject _instructionMenu = default;
    [SerializeField] GameObject _startButtons = default;
    private bool _isInstructionOn = false;
    private float _timeStart;


    // Start is called before the first frame update
    void Start()
    {
        _isInstructionOn = false;
    }

    // Update is called once per frame
    public void Instruction()
    {
        if (!_isInstructionOn)
        {
            Debug.Log("instruction up");
            _instructionMenu.SetActive(true);
            _startButtons.SetActive(false);
            Time.timeScale = 0;
            _isInstructionOn = true;
        }
        else if (_isInstructionOn)
        {
            Debug.Log("instruction down");
            _instructionMenu.SetActive(false);
            _startButtons.SetActive(true);
            Time.timeScale = 1;
            _isInstructionOn = false;
        }
    }

    public void SetTime()
    {
        _timeStart = Time.time;
    }

    public float GetTime()
    {
        return _timeStart;
    }


}
