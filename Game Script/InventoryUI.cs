using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public SlotUI slotPrefab;

    void Start()
    {
        Refresh();
        inventory.ChangeEvent.AddListener(Refresh);
    }

    void Refresh()
    {
        DestroyAllChildren();
        foreach (var slot in inventory.SlotList)
        {
            SlotUI instButton = Instantiate(slotPrefab);
            var localSlot = slot;
            instButton.transform.SetParent(transform);
            instButton.Init(localSlot);
            instButton.button.onClick.AddListener(() => inventory.DropItem(localSlot.item));
        }
    }

    void DestroyAllChildren()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
