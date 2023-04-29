using UnityEngine;

public class RepairHole : MonoBehaviour, Interactable
{
    [SerializeField] ItemSO neededObject;
    bool _hasTheRightTool;

    public void Interact()
    {
        for (int i = 0; i < PlayerInventory.Instance.Inventory.Count; i++)
        {
            if (PlayerInventory.Instance.Inventory[i] == neededObject)
            {
                _hasTheRightTool = true;
                Debug.Log("Hole Repaired!");
                GameManager.Instance.SetRepairedHole(true);
                PlayerInventory.Instance.RemoveFromInventory(neededObject);
                return;
            }
        }

        if(!_hasTheRightTool)
        {
            Debug.Log("You don't have the right tool...");
        }
    }
}
