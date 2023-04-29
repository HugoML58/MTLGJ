using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour, Interactable
{
    [SerializeField] KeyItems keyItemType;

    GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.Instance;
    }

    public void Interact()
    {
        Debug.Log("Picked up : " + gameObject.name);
        switch (keyItemType)
        {
            case KeyItems.Helmet:
                _gameManager.SetSuit(true);
                break;
            case KeyItems.Oxygen:
                _gameManager.SetOxygen(true);
                break;
        }
        Destroy(gameObject);
    }
}

public enum KeyItems
{
    Helmet,
    Oxygen
}

