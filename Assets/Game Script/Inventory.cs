using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;

public class Inventory : MonoBehaviour {
	[Serializable]
	public class Slot{
		public Item item;
		public int count;
		public bool Empty{get{return item == null;}}
		public bool Full{get{return count >= item.maxStack;}}
	}

	public List<Slot> SlotList;
    public UnityEvent ChangeEvent;

	public bool AddItem(Item item)
	{
        Slot sameItemSlot = FindOne (item);
		if (sameItemSlot != null && !sameItemSlot.Full){
            sameItemSlot.count++;
            ChangeEvent.Invoke();
            return true;
		}
		Slot emptySlot = GetEmptySlot ();
		if (emptySlot != null) {
			emptySlot.item = item;
			emptySlot.count = 1;
            ChangeEvent.Invoke();
            return true;
        }
        return false;
	}

    public bool DropItem(Item item)
    {
        ChangeEvent.Invoke();
        Slot itemSlot = FindOne(item);
        if (itemSlot != null)
        {
            itemSlot.count--;
            if (itemSlot.count == 0)
                itemSlot.item = null;
            Generator.Generate(item, transform.position);
            ChangeEvent.Invoke();
            return true;
        }
        return false;
    }

	public Slot FindOne(Item item)
	{
	    return SlotList.FirstOrDefault(slot => !slot.Empty && slot.item == item && !slot.Full);
	}

    public Slot GetEmptySlot()
    {
        return SlotList.FirstOrDefault(slot => slot.Empty);
    }
}
