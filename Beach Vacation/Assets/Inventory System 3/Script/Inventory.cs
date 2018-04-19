using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour {

	public bool inventoryEnabled;
	public GameObject inventory;
	public GameObject itemDatabase;
	public GameObject slotHolder;

	private int slots;
	private Transform[] slot;

	private GameObject itemPickedUp;
	private bool itemAdded;


	public void Start()
	{

		slots = slotHolder.transform.childCount;
		slot = new Transform[slots];
		DetectInventorySlots();
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.I))
				inventoryEnabled = !inventoryEnabled;

		if (inventoryEnabled)
				inventory.SetActive(true);
		else
				inventory.SetActive(false);


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


	public void OnTriggerEnter(Collider other)							// when you walk over a pickupable object
	{
		if (other.tag == "Item")
		{
			itemPickedUp = other.gameObject;
			AddItem(other.gameObject);
		}
	}

	public void OnTriggerExit(Collider other)							// when you walk over a pickupable object
	{
		if (other.tag == "Item")
		{
			itemAdded = false;
		}
	}

	public void AddItem(GameObject item)									/// adding them to inventory
	{
		// GameObject rootItem;
		// rootItem = item.GetComponent<ItemPickup>().rootItem;
		// print(rootItem);

		for(int i = 0; i < slots; i++)
		{
			if (slot[i].GetComponent<Slot>().empty && itemAdded == false)
			//if(slot[i].GetComponent<Slot>().empty == true && item.gameObject.GetComponent<ItemPickup>().pickedUp == false)
			{
				// slot[i].GetComponent<Slot>().item = rootItem;
				// item.GetComponent<ItemPickup>().pickedUp = true;

				slot[i].GetComponent<Slot>().item = itemPickedUp;
				//slot[i].GetComponent<Slot>().itemTexture = itemPickedUp.GetComponent<Item>().itemTexture;
				item.transform.parent = itemDatabase.transform;     //actually add to itemdatabase
				item.transform.position = itemDatabase.transform.position;
				itemAdded = true;
				print("item suppose to be added");

				if (item.GetComponent<MeshRenderer>())
					item.GetComponent<MeshRenderer>().enabled = false;
					
				Destroy(item.GetComponent<Rigidbody>());
			}
		}

	}

	public void DetectInventorySlots()
	{

		for (int i = 0; i < slots; i++)
		{
			slot[i] = slotHolder.transform.GetChild(i);
			//print(slot[i].gameObject.name);

		}

	}

}
