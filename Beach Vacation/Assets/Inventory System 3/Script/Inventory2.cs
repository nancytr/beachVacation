using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory2 : MonoBehaviour {

	public bool inventory2Enabled;
	public GameObject inventory2;
	public GameObject itemDatabase;
	private Transform[] slot2;
	public GameObject slotHolder;
	private GameObject pickedUpItem;
	private bool itemAdded;


	public void Start()
	{
		DetectInventorySlots();
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.I))
				inventory2Enabled = !inventory2Enabled;

		if (inventory2Enabled)
				inventory2.SetActive(true);
		else
				inventory2.SetActive(false);


		//check for slots
		// Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		// RaycastHit hit;
		//
		// if (Physics.Raycast(ray, out hit))
		// {
		// 	print("raycasting");
		// 	if (hit.transform.tag == "Slot")
		// 	{
		// 		print(hit.transform.name);
		// 	}
		// }
	}


	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Item")
		{
			pickedUpItem= other.gameObject;
			AddItem(pickedUpItem);
		}
	}

	public void OnTriggerExit(Collider other)
	{
		if (other.tag == "Item")
		{
			itemAdded = false;
		}
	}

	public void AddItem(GameObject item)
	{
		GameObject rootItem;
		rootItem = item.GetComponent<ItemPickup2>().rootItem;
		print(rootItem);

		for(int i = 0; i < 12; i++)
		{
			if(slot2[i].GetComponent<Slot2>().empty && itemAdded == false)
			{
				slot2[i].GetComponent<Slot2>().item = pickedUpItem;
				slot2[i].GetComponent<Slot2>().itemIcon = pickedUpItem.GetComponent<Item>().icon;
				itemAdded = true;
				//item.GetComponent<ItemPickup2>().pickedUp = true;
				Destroy(item);
			}
		}

	}

	public void DetectInventorySlots()
	{

		for (int i = 0; i < slots; i++)
		{
			slot2[i] = slotHolder.transform.GetChild(i);
			// print(slot2[i].gameObject.name);
		}
	}

}
