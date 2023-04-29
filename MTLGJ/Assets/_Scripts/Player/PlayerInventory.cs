using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }

    [SerializeField] int inventorySlots = 3;

    private List<ItemSO> _inventory = new List<ItemSO>();
    
    private void Awake()
    {
        #region Singleton

        if (Instance != null && Instance != this) Destroy(Instance);
        else Instance = this;

        #endregion
    }

    public bool TryAddToInventory()
    {
        if(_inventory.Count > inventorySlots - 1) return false;
        else return true;
    }

    public void AddToInventory(ItemSO item)
    {
        _inventory.Add(item);
        UIManager.Instance.UpdateInventorySlotIcon(item, _inventory.Count - 1, false);
    }

    public void RemoveFromInventory(ItemSO item)
    {
        for (int i = 0; i < _inventory.Count; i++)
        {
            if(item == _inventory[i])
            {
                UIManager.Instance.UpdateInventorySlotIcon(item, _inventory.Count - 1, true);
                _inventory.Remove(item);
            }
        }
    }

    public List<ItemSO> GetInventory() { return _inventory; }
}
