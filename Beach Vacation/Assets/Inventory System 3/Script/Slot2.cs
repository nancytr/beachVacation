using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot2 : MonoBehaviour, IPointerEnterHandler
{

		[SerializeField] public bool empty;
		public Texture slotTexture;
		public Texture itemTexture;
		public GameObject item;



		void Update()
		{

			//changing Texture
			if (item)
			{
				this.GetComponent<RawImage>().texture = itemTexture;
				empty = false;
			} else {
				this.GetComponent<RawImage>().texture = slotTexture;
				empty = true;
			}

		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			print (this.gameObject.name);

			
		}




}
