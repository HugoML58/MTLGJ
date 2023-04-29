using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    InputsListener Input;

    [SerializeField]
    float interactRange = 2f;

    [SerializeField]
    Transform Camera;

    void Update()
    {
        if (Input.Interact)
        {
            bool collision = Physics.Raycast(
                Camera.position,
                Camera.forward,
                out RaycastHit HitInfo,
                interactRange
            );

            // if (collision.TryGetComponent(out Interactable interactable))
            // {
            //     interactable.Interact();
            // }

            if (collision)
            {
                if (HitInfo.transform.TryGetComponent(out Interactable interactable))
                {
                    interactable.Interact();
                    Debug.Log("hit");
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        // Gizmos.color = Color.yellow;
        // Gizmos.DrawWireSphere(transform.position, interactRange);

        Gizmos.color = Color.blue;
        Ray ray = new Ray(Camera.position, Camera.forward*interactRange);
        Gizmos.DrawRay(ray);
    }
}
