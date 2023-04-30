using System;
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

    bool _isGamePaused;

    public static event Action<bool> OnGamePaused;

    private void Awake()
    {
        #region Singleton

        if (Instance != null && Instance != this)
            Destroy(Instance);
        else
            Instance = this;

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
        if (_hasSuit && _hasOxygen)
        {
            _isEquiped = true;
            UIManager.Instance.ShowEquipedSuitIcon();
        }
        checkComplete();
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
        if (
           _hasRepairedPressure
            && _hasRepairedFuel
            && _hasRepairedO2Tube
            && _hasRepairedElectronics
        )
        {
            _hasRepairedRocket = true;
        }
        checkComplete();
    }

    private void checkComplete()
    {
        if (_hasRepairedRocket && _hasSuit)
        {
            EndGame();
        }

    }

    public void EndGame()
    {
        //TODO : Add cinematics in function of the result
        if (_hasRepairedRocket && _isEquiped)
        {
            Debug.Log("Yay!");
            SceneManager.LoadSceneAsync(3);
        }
        else
        {
            Debug.Log("BOOM!");
            SceneManager.LoadSceneAsync(2);
        }
    }

    public void Pause()
    {
        _isGamePaused = !_isGamePaused;

        if (_isGamePaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }
        OnGamePaused?.Invoke(_isGamePaused);
    }
}
