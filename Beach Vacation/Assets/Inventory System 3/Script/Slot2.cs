using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot2 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

		public bool empty;
	//	public Texture slotTexture;
	//	public Texture itemTexture;
		public GameObject item;
		private int slots;
		private bool hovered;
		public Texture itemIcon;
		private GameObject player;



		void Start()
		{
			hovered = false;
			player = GameObject.FindWithTag("Player");
		}

		void Update()
		{

			//changing Texture
			if (item)
			{
				empty = false;
				itemIcon = item.GetComponent<Item>().icon;
				this.GetComponent<Item>().texture = itemIcon;

			} else {

				empty = true;
			}

		}

		public void OnPointerEnter(PointerEventData PointerEventData)
		{
			hovered = true;
			if(item)
				print(item.name);
				item.SetActive(true);
		}


		public void OnPointerExit(PointerEventData eventData)
		{
			hovered = false;
		}


		public void OnPointerClick(PointerEventData eventData)
		{
			if (item)
			{
				Item2 thisItem = item.GetComponent<Item2>();

				//checking for item type
				// if (thisItem.type == "Water")
			}


		}
}
