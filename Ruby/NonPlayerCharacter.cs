using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    public float _displayTime = 4.0f;
    public GameObject _dialogBox;
    float _timerDisplay;
    // Start is called before the first frame update
    void Start()
    {
        _dialogBox.SetActive(false);
        _timerDisplay = -1.0f;

    }

    // Update is called once per frame
    void Update()
    {

        if (_timerDisplay >= 0)
        {
            _timerDisplay -= Time.deltaTime;
            if (_timerDisplay < 0)
            {
                _dialogBox.SetActive(false);
            }
        }
    }
    public void DisplayDialog(){
        _timerDisplay = _displayTime;
        _dialogBox.SetActive(true);
    }
}
