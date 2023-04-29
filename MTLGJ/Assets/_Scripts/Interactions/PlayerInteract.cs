using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    InputsListener Input;

    [SerializeField]
    LayerMask interactable;

    private float interactRange = 2f;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (Input.Interact)
        {
            Collider[] colliderArray = Physics.OverlapSphere(
                transform.position,
                interactRange,
                interactable
            );
            for (int i = 0; i < colliderArray.Length; i++)
            {
                if (colliderArray[i].TryGetComponent(out Interactable interactable))
                {
                    interactable.Interact();
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
