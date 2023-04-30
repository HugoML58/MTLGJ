using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] float timeRemaining = 1800;
    [SerializeField] float[] keyTimes;

    int _nextKeyTimeValue;
    bool _hasReachedLastKeyTime;
    bool _isTimerPause;

    void Update()
    {
        if(!_isTimerPause)
        {
            timeRemaining -= Time.deltaTime;

            if(!_hasReachedLastKeyTime && timeRemaining <= keyTimes[_nextKeyTimeValue])
            {
                UIManager.Instance.ShowRemainingTimeText(keyTimes[_nextKeyTimeValue]);
                _nextKeyTimeValue++;
                if(_nextKeyTimeValue == keyTimes.Length)
                {
                    _hasReachedLastKeyTime = true;
                }
            }

            if (timeRemaining <= 0 && timeRemaining > -1)
            {
                //TODO : Execute 2 times?
                GameManager.Instance.EndGame();
                this.enabled = false;
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
