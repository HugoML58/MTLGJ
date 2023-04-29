using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] float timeRemaining = 1800;

    void Update()
    {
        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            //TODO : Execute 2 times?
            GameManager.Instance.EndGame();
        }
    }
}
