using UnityEngine;

public class Item : MonoBehaviour, Interactable
{
    public ItemSO item;

    public void Interact()
    {
        bool canAddToInventory = PlayerInventory.Instance.TryAddToInventory();
        if (canAddToInventory)
        {
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
