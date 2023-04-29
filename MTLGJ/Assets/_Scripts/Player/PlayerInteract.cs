using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    InputsListener Input;

    [SerializeField]
    float interactRange = 2f;

    void Update()
    {
        if (Input.Interact)
        {
            Collider[] colliderArray = Physics.OverlapSphere(
                transform.position,
                interactRange
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
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
