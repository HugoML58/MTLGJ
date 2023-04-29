using UnityEngine;

public class RepairHole : MonoBehaviour, Interactable
{
    [SerializeField] ItemSO neededObject;

    PlayerInventory _playerInventory;

    private void Start()
    {
        _playerInventory = PlayerInventory.Instance;
    }

    public void Interact()
    {
        for (int i = 0; i < _playerInventory.GetInventory().Count; i++)
        {
            if (_playerInventory.GetInventory()[i] == neededObject)
            {
                //TODO : Feedback?
                Debug.Log("Hole Repaired!");
                GameManager.Instance.SetRepairedHole(true);
                _playerInventory.RemoveFromInventory(neededObject);
                return;
            }
        }

        Debug.Log("You don't have the right tool...");
    }
}
