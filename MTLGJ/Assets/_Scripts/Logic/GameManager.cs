using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //asaddad
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

    bool _isGamePaused;

    [SerializeField] EndingAnimationCam ECam;

    public static event Action<bool> OnGamePaused;

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
            UIManager.Instance.ShowEquipedSuitIcon();
        }
    }

    public void SetRepairedHole(bool state)
    {
        _hasRepairedHole = state;
        CheckForAllRepair();
    }

    public void SetHasRepairedPressure(bool state)
    {
        _hasRepairedPressure = state;
        CheckForAllRepair();
    }

    public void SetHasRepairedFuel(bool state)
    {
        _hasRepairedFuel = state;
        CheckForAllRepair();
    }

    public void SetHasRepairedO2Tube(bool state)
    {
        _hasRepairedO2Tube = state;
        CheckForAllRepair();
    }

    public void SetHasRepairedElectronics(bool state)
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
            ECam.ActivateCam(true);
        }
        else if (!_isEquiped)
        {
            Debug.Log("Dead.");
            ECam.ActivateCam(false);
            // SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            Debug.Log("BOOM!");
            ECam.ActivateCam(false);
            // SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Pause()
    {
        _isGamePaused = !_isGamePaused;

        if( _isGamePaused )
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1; 
        }
        OnGamePaused?.Invoke(_isGamePaused);
    }
}
