using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] Image equipedSuitIcon;
    [SerializeField] Image[] slotsIcons;
    [SerializeField] TextMeshProUGUI timeRemainingText;
    
    private void Awake()
    {
        #region Singleton

        if (Instance != null && Instance != this) Destroy(Instance);
        else Instance = this;

        #endregion
    }

    public void ShowEquipedSuitIcon()
    {
        equipedSuitIcon.gameObject.SetActive(true);
    }

    public void UpdateInventorySlotIcon(ItemSO item, int slotNumber, bool remove)
    {
        if(!remove)
        {
            slotsIcons[slotNumber].gameObject.SetActive(true);
            slotsIcons[slotNumber].sprite = item.ItemIcon;
        }
        else
        {
            slotsIcons[slotNumber].sprite = null;
            slotsIcons[slotNumber].gameObject.SetActive(false);
        }
    }

    public void ShowRemainingTimeText(float time)
    {
        timeRemainingText.SetText("{0} minutes remaining before launch", time);
    }
}
