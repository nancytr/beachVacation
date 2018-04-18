using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public delegate void OnItemChanged();
	public OnItemChanged OnItemChangedCallback;
	public int space = 11;			// AMOUNT OF INVENTORY SPACE

	public static Inventory instance;

	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance of Inventory found!");
			return;
		}

		instance = this;
	}


	public List<Item> items = new List<Item>();

	public bool Add (Item item)
	{
		{
			if (items.Count >= space)
			{
				Debug.Log("Not enough space.");
				return false;		// IF WE DIDNT ADD ITEM
			}

			items.Add(item);

			if (OnItemChangedCallback != null)
				OnItemChangedCallback.Invoke();		// UI WILL UPDATE

		}

		return true;				// IF WE DID ADD ITEM
	}

	public void Remove (Item item)
	{
		items.Remove(item);

		if (OnItemChangedCallback != null)
			OnItemChangedCallback.Invoke();		// UI WILL UPDATE
	}

}
