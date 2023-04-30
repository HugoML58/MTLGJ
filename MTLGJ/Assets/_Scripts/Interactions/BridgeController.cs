using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour, Interactable
{

    [SerializeField] BridgeCollider BridgeCollider;

    public void Interact()
    {
        BridgeCollider.ActivateBridge();
    }
}
