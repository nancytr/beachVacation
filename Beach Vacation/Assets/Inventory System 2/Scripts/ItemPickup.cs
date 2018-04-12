using UnityEngine;

public class ItemPickup : Interactable{

	public Item item;			// Item put into inventory if picked up

	public override void Interact()
	{

		base.Interact();

		PickUp();
	}

	void PickUp ()
	{

			Debug.Log("Picking up " + item.name);
			bool wasPickedUp = Inventory.instance.Add(item);			// Add to Inventory


			if (wasPickedUp)
				Destroy(gameObject);			// Destory item from scene
	}
}
