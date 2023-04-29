using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    bool _hasSuit;
    bool _hasOxygen;
    bool _isEquiped;

    bool _hasRepairedPressure;
    bool _hasRepairedFuel;
    bool _hasRepairedO2Tube;
    bool _hasRepairedElectronics;
    bool _hasRepairedHole;
    bool _hasRepairedRocket;

    private void Awake()
    {
        #region Singleton

        if (Instance != null && Instance != this) Destroy(Instance);
        else Instance = this;

        #endregion
    }

    public void SetSuit(bool state)
    {
        _hasSuit = state;
        CheckEquiped();
    }

    public void SetOxygen(bool state)
    {
        _hasOxygen = state;
        CheckEquiped();
    }

    private void CheckEquiped()
    {
        if(_hasSuit && _hasOxygen)
        {
            _isEquiped = true;
        }
    }

    public void SetRepairedHole(bool state)
    {
        _hasRepairedHole = state;
        CheckForAllRepair();
    }

    public void SetHasRepaired01(bool state)
    {
        _hasRepairedPressure = state;
        CheckForAllRepair();
    }

    public void SetHasRepaired02(bool state)
    {
        _hasRepairedFuel = state;
        CheckForAllRepair();
    }

    public void SetHasRepaired03(bool state)
    {
        _hasRepairedO2Tube = state;
        CheckForAllRepair();
    }

    public void SetHasRepaired04(bool state)
    {
        _hasRepairedElectronics = state;
        CheckForAllRepair();
    }

    private void CheckForAllRepair()
    {
        if(_hasRepairedHole && _hasRepairedPressure && _hasRepairedFuel && _hasRepairedO2Tube && _hasRepairedElectronics)
        {
            _hasRepairedRocket = true;
        }
    }

    public void EndGame()
    {
        //TODO : Add cinematics in function of the result
        if (_hasRepairedRocket && _isEquiped)
        {
            Debug.Log("Yay!");
        }
        else if (!_isEquiped)
        {
            Debug.Log("Dead.");
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            Debug.Log("BOOM!");
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
