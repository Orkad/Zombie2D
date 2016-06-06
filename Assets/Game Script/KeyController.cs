using UnityEngine;
using System.Collections;

public class KeyController : MonoBehaviour
{
    public Inventory inventory;
    public Item itemToDrop;
	
	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetKeyDown(KeyCode.Return))
	        inventory.DropItem(itemToDrop);
	}
}
