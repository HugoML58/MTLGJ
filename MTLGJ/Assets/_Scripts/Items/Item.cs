using UnityEngine;

public class Item : MonoBehaviour, Interactable
{
    public ItemSO item;

    public void Interact()
    {
        Debug.Log("Picked up : " + gameObject.name);
        Collect();
    }

    private void Collect()
    {
        PlayerInventory.Instance.AddToInventory(item);
        Destroy(gameObject);
    }
}
