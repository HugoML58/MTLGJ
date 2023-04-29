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
        bool hitInteractable = Physics.Raycast(Camera.position, Camera.forward, out RaycastHit RaycastHitInteractable, interactRange);
        if(hitInteractable)
        {
            if(RaycastHitInteractable.transform.TryGetComponent(out Interactable interactable))
            {
                Debug.Log("AAA");
            }
        }

        if (Input.Interact)
        {
            bool collision = Physics.Raycast(Camera.position, Camera.forward, out RaycastHit HitInfo, interactRange);
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
        Gizmos.color = Color.blue;
        Ray ray = new Ray(Camera.position, Camera.forward*interactRange);
        Gizmos.DrawRay(ray);
    }
}
