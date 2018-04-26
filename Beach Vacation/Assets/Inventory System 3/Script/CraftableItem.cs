﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CraftableItem : MonoBehaviour, IPointerEnterHandler {

	public GameObject thisItem;
	public int requiredItems;
	public GameObject[] items;
	public GameObject itemManager;

	private bool hovered;
	private GameObject player;


	public void Start()
	{
		player = GameObject.FindWithTag("Player");
		itemManager = GameObject.FindWithTag("itemManager");
	}

	public void Update()
	{
		if (hovered == true)
		{
			if (Input.GetMouseButtonDown(0))
			{
				CheckForRequiredItems();
			}
		}
	}

	public void CheckForRequiredItems()
	{
		print("checking for items!");
		int itemsInManager = itemManager.transform.childCount;

		if (itemsInManager > 0)
		{
			print(" still checking for items!");
			int itemsFound = 0;

			for (int i = 0; i < itemsInManager; i++)
			{
				for (int z = 0; z < requiredItems; z++)
				{
					if (itemManager.transform.GetChild(i).GetComponent<Item2>().type == items[z].GetComponent<Item2>().type)
						{
							print("item found");
							itemsFound++;
							break;
						}
				}

				if (itemsFound >= requiredItems)
				{
					//trying to delete from inventory after crafting
					for (int z = 0; z < requiredItems; z++)
					{
						if (itemManager.transform.GetChild(i).GetComponent<Item2>().type == items[z].GetComponent<Item2>().type)
							{
								Destroy(itemManager.transform.GetChild(i).GetComponent<Item2>());
								print("deleted");
								break;
							}
					}

					// making crafted item
					Vector3 pos = new Vector3(player.transform.position.x , player.transform.position.y - 1, player.transform.position.z);
					GameObject craftedItem = Instantiate(thisItem, pos, Quaternion.identity);
					//player.GetComponent<Inventory2>()AddItem(craftedItem);
					print("all items are found");

				}

			}
		}
	}


	public void OnPointerEnter(PointerEventData eventData)
	{
		hovered = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		hovered = false;
	}
}
