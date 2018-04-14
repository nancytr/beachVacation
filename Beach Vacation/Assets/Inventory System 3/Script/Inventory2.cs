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

		if(pickedUpItem == true)
		{
			float waitTimer = 0.5f;
			waitTimer = 1 * Time.deltaTime;

		}


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
			print("Item triggered");
			if (pickedUpItem == false)
				AddItem(other.gameObject);
		}
	}

	public void AddItem(GameObject item)
	{
		GameObject rootItem;
		rootItem = item.GetComponent<ItemPickup2>().rootItem;

		for(int i = 0; i < 25; i++)
		{
			if(slot2[i].GetComponent<Slot2>().empty == true)
			{
				slot2[i].GetComponent<Slot2>().item = rootItem;
				Destroy(item);
				pickedUpItem = true;
			}
		}

	}

	public void GetAllSlots()
	{
		slot2 = new Transform[25];
		for (int i = 0; i < 25; i++)
		{
			slot2[i] = slotHolder.transform.GetChild(i);
			print(slot2[i].gameObject.name);
		}
	}

}
