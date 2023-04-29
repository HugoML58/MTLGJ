using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeCollider : MonoBehaviour
{
    [SerializeField] Collider Bridge;
    
    
    
    public static bool BridgeDown;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateBridge() {
        Bridge.enabled = !Bridge.enabled;
    }
}
