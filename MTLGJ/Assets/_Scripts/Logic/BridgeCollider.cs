using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeCollider : MonoBehaviour
{
    [SerializeField] Collider Bridge;
    [SerializeField] Animator bridgeAnimator;
    
    public void ActivateBridge()
    {
        bridgeAnimator.SetBool("ActivateBridge", true);
        Bridge.enabled = true;
    }
}
