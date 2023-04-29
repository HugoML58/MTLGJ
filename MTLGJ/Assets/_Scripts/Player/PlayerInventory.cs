using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }

    public List<ItemSO> Inventory = new List<ItemSO>();
    
    private void Awake()
    {
        #region Singleton

        if (Instance != null && Instance != this) Destroy(Instance);
        else Instance = this;

        #endregion
    }

    public void AddToInventory(ItemSO item)
    {
        Inventory.Add(item);
    }

    public void RemoveFromInventory(ItemSO item)
    {
        for (int i = 0; i < Inventory.Count; i++)
        {
            if(item == Inventory[i])
            {
                Inventory.Remove(item);
            }
        }
    }
}
