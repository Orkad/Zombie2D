using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent(typeof(Collider2D),typeof(SpriteRenderer))]
public class GroundItem : MonoBehaviour {
	public Item refItem;
	public Collider2D col { get { return GetComponent<Collider2D> (); } }
	public SpriteRenderer sr { get { return GetComponent<SpriteRenderer> (); } }
    public bool droppable;

	void Start () {
		sr.sprite = refItem.sprite;
	}

	void DestroyMe(){
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D other){
		var inventory = other.GetComponent<Inventory> ();
		if (droppable && inventory != null)
			if (inventory.AddItem (refItem))
				DestroyMe ();
	}

    void OnTriggerExit2D(Collider2D other)
    {
        var inventory = other.GetComponent<Inventory>();
        if (inventory != null)
            droppable = true;
    }
}
