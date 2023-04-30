using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    InputsListener Input;

    [SerializeField]
    float interactRange = 2f;

    [SerializeField]
    Transform playerCamera;

    void Update()
    {
        bool hitInteractable = Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit RaycastHitInteractable, interactRange);
        if(hitInteractable)
        {
            if(RaycastHitInteractable.transform.TryGetComponent(out Interactable interactable))
            {
                UIManager.Instance.ShowInteractText(RaycastHitInteractable.transform.name);
            }
        }
        else UIManager.Instance.ShowInteractText("");

        if (Input.Interact)
        {
            bool collision = Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit HitInfo, interactRange);
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
        Gizmos.DrawLine(playerCamera.position, playerCamera.position + (playerCamera.forward * interactRange));

    }
}
