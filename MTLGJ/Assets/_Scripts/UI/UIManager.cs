using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] TextMeshProUGUI interactText;
    [SerializeField] Image equipedSuitIcon;
    [SerializeField] Image[] slotsIcons;
    [SerializeField] TextMeshProUGUI timeRemainingText;
    [SerializeField] TextWriter timeRemainingTextWriter;
    [SerializeField] GameObject pauseMenu;
    
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
        timeRemainingTextWriter.AddWriter(timeRemainingText, string.Format("{0} minutes remaining before launch", time / 60), 0.15f);
    }

    public void ShowInteractText(string interactableName)
    {
        interactText.SetText(interactableName);
    }

    public void ShowPauseMenu(bool state)
    {
        pauseMenu.SetActive(state);
    }

    private void OnEnable()
    {
        GameManager.OnGamePaused += ShowPauseMenu;
    }
    private void OnDisable()
    {
        GameManager.OnGamePaused -= ShowPauseMenu;
    }
}
