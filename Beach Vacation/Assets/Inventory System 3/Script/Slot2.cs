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

		private Player player;



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

				if (PointerEventData.button == PointerEventData.InputButton.Right)			// drops item into game world
				{
					print(item.name);
					item.SetActive(true);


					// adds item back into game world and removes all trace from inventory
					itemTexture = null;
					this.GetComponent<RawImage>().texture = null;
					item.GetComponent<ItemPickup2>().pickedUp = false;
					print(item.GetComponent<ItemPickup2>().pickedUp);

					// item.GetComponent<MeshRenderer>().enabled = true;

					// need instantiate
					Vector3 plyrP = new Vector3(playerChar.transform.position.x, playerChar.transform.position.y + 3, playerChar.transform.position.z);
					Instantiate(item, plyrP + (playerChar.transform.forward * (int)2), Quaternion.identity);
					Destroy(item);

					// other form of placing it back at feet
					// item.transform.position = new Vector3 (playerChar.transform.position.x + 5f, 10.0f, playerChar.transform.position.z);

					item = null;
				}
				else if(PointerEventData.button == PointerEventData.InputButton.Left && item.GetComponent<ItemProperties>().craftable == false)
				{

					// print ("leftmousebutton");
					// put item properties time stuff
					ItemProperties properties = item.GetComponent<ItemProperties>();
					properties.Interaction(playerChar.GetComponent<Player>());
					print("itemproperties");
					Destroy(item);
					//item.SetActive(false);
					item = null;

				}

		}


		public void OnPointerEnter(PointerEventData eventData)
		{
			// print(item.name + " haha");
		}

}
