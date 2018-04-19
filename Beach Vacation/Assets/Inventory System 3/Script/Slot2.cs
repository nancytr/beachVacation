using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot2 : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{

		[SerializeField] public bool empty;
		public Texture slotTexture;
		public Texture itemTexture;
		public GameObject item;
		public GameObject playerChar;



		void Update()
		{

			//changing Texture
			if (item)
			{
				itemTexture = item.GetComponent<Item2>().itemTexture;
				// print("gotchabitch");

				this.GetComponent<RawImage>().texture = itemTexture;
				empty = false;
			} else {
				this.GetComponent<RawImage>().texture = slotTexture;
				empty = true;
			}

		}

		public void OnPointerDown(PointerEventData PointerEventData)
		{
			if(item)
				print(item.name);
				item.SetActive(true);
				
				

				// adds item back into game world and removes all trace from inventory
				itemTexture = null;
				this.GetComponent<RawImage>().texture = null;
				item.GetComponent<ItemPickup2>().pickedUp = false;
				print(item.GetComponent<ItemPickup2>().pickedUp);
				
				// item.GetComponent<MeshRenderer>().enabled = true;

				// need instantiate
				// Instantiate(item, playerChar.transform.position, Quaternion.identity);

				// other form of placing it back at feet
				item.transform.position = new Vector3 (playerChar.transform.position.x, 10.0f, playerChar.transform.position.z);
				
				item = null;

				

		}


		public void OnPointerEnter(PointerEventData eventData)
		{
			print(item.name + " haha");
		}

}
