using UnityEngine;

public class Item : MonoBehaviour, Interactable
{
    [SerializeField] AudioClip clip;
    public ItemSO item;

    public void Interact()
    {
        bool canAddToInventory = PlayerInventory.Instance.TryAddToInventory();
        if (canAddToInventory)
        {
            SFXManager.instance.PlaySFX(clip);
            Debug.Log("Picked up : " + gameObject.name);
            PlayerInventory.Instance.AddToInventory(item);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Inventory is full");
        }
    }
}
