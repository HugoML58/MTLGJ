using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairPressure : MonoBehaviour, Interactable
{
    [SerializeField] AudioClip clip;
    [SerializeField] AudioSource source;

    public void Interact()
    {
        SFXManager.instance.PlaySFX(clip);
        Destroy(source);
        Debug.Log("Pressure Repaired!");
        GameManager.Instance.SetHasRepairedPressure(true);
    }
}
