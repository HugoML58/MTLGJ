using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    bool _hasRepaired01;
    bool _hasRepaired02;
    bool _hasRepaired03;
    bool _hasRepaired04;
    bool _hasRepairedHole;
    bool _hasRepairedRocket;

    private void Awake()
    {
        #region Singleton

        if (Instance != null && Instance != this) Destroy(Instance);
        else Instance = this;

        #endregion
    }

    public void SetRepairedHole(bool state)
    {
        _hasRepairedHole = state;
        CheckForAllRepair();
    }

    public void SetHasRepaired01(bool state)
    {
        _hasRepaired01 = state;
        CheckForAllRepair();
    }

    public void SetHasRepaired02(bool state)
    {
        _hasRepaired02 = state;
        CheckForAllRepair();
    }

    public void SetHasRepaired03(bool state)
    {
        _hasRepaired03 = state;
        CheckForAllRepair();
    }

    public void SetHasRepaired04(bool state)
    {
        _hasRepaired04 = state;
        CheckForAllRepair();
    }

    private void CheckForAllRepair()
    {
        if(_hasRepairedHole && _hasRepaired01 && _hasRepaired02 && _hasRepaired03 && _hasRepaired04)
        {
            _hasRepairedRocket = true;
        }
    }

    public void EndGame()
    {
        //TODO : Add cinematics in function of the result
        if (_hasRepairedRocket)
        {
            Debug.Log("Yay!");
        }
        else
        {
            Debug.Log("BOOM!");
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
