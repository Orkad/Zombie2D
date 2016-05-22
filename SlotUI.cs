using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    public Image image;
    public Text text;
    public Button button { get { return GetComponent<Button>(); } }

    public void Init(Inventory.Slot slot)
    {
        if (slot.Empty)
        {
            text.text = "";
            return;
        }  
        image.sprite = slot.item.icon;
        text.text = slot.count.ToString();
    }
}
