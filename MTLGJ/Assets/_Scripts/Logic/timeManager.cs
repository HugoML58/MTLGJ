using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] float timeRemaining = 1800;

    bool _isTimerPause;

    void Update()
    {
        if(!_isTimerPause)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                //TODO : Execute 2 times?
                GameManager.Instance.EndGame();
            }
        }
    }

    public void StopTime(bool state)
    {
        _isTimerPause = state;
    }

    private void OnEnable()
    {
        GameManager.OnGamePaused += StopTime;
    }

    private void OnDisable()
    {
        GameManager.OnGamePaused -= StopTime;
    }
}
