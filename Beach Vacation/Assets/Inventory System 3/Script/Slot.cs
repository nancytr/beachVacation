using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

		public bool empty;
		public Texture itemTexture;
		public GameObject item;

		private bool hovered;
		private GameObject player;
		private ItemProperties itemProperties;

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
				itemTexture = item.GetComponent<Item>().itemTexture;
				this.GetComponent<RawImage>().texture = itemTexture;


			} else {
				empty = true;
				itemTexture = null;
				this.GetComponent<RawImage>().texture = null;
			}

		}

		public void OnPointerEnter(PointerEventData PointerEventData)
		{
			hovered = true;
			if(item)
				print(item.name + "yoooo");
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
				Item thisItem = item.GetComponent<Item>();					// try to get item protperies and it's interaction properi


				//checking for item type
				// if (thisItem.type == "Water")
				// {
				// 	player.GetComponent<Player>().Drink(thisItem.decreaseRate);
		  }
		}



}
