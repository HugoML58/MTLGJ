using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairElectronics : MonoBehaviour, Interactable
{
    [SerializeField] AudioClip clip;
    [SerializeField]
    ItemSO neededObject;

    PlayerInventory _playerInventory;

    private void Start()
    {
        _playerInventory = PlayerInventory.Instance;
    }

    public void Interact()
    {
        for (int i = 0; i < _playerInventory.GetInventory().Count; i++)
        {
            if (_playerInventory.GetInventory()[i] == neededObject)
            {
                SFXManager.instance.PlaySFX(clip);
                Debug.Log("Elec Repaired!");
                GameManager.Instance.SetHasRepairedElectronics(true);
                _playerInventory.RemoveFromInventory(neededObject);
                return;
            }
        }

        Debug.Log("You don't have the right tool...");
    }
}
