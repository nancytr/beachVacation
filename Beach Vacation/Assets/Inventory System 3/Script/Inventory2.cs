using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory2 : MonoBehaviour {

	public bool inventory2Enabled;
	public GameObject inventory2;
	public GameObject itemDatabase;
	private Transform[] slot2;
	public GameObject slotHolder;
	private bool pickedUpItem;


	public void Start()
	{
		GetAllSlots();
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
			AddItem(other.gameObject);
		}
	}

	public void AddItem(GameObject item)
	{
		GameObject rootItem;
		rootItem = item.GetComponent<ItemPickup2>().rootItem;
		print(rootItem);

		for(int i = 0; i < 12; i++)
		{
			if(slot2[i].GetComponent<Slot2>().empty == true && item.gameObject.GetComponent<ItemPickup2>().pickedUp == false)
			{
				slot2[i].GetComponent<Slot2>().item = rootItem;
				item.GetComponent<ItemPickup2>().pickedUp = true;
				Destroy(item);
			}
		}

	}

	public void GetAllSlots()
	{
		slot2 = new Transform[12];
		for (int i = 0; i < 12; i++)
		{
			slot2[i] = slotHolder.transform.GetChild(i);
			// print(slot2[i].gameObject.name);
		}
	}

}
