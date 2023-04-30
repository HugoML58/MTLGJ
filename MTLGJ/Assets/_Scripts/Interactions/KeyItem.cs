using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour, Interactable
{
    [SerializeField] AudioClip clip;
    [SerializeField] KeyItems keyItemType;

    GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.Instance;
    }

    public void Interact()
    {
        SFXManager.instance.PlaySFX(clip);
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
        Destroy(this.gameObject);
    }
}

public enum KeyItems
{
    Helmet,
    Oxygen
}

