using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	public Texture itemTexture;

	public string type;
	[SerializeField] public ItemProperties itemProperties;

	public void Update()
	{
		if(Input.GetKeyDown(KeyCode.F))
		{
			this.gameObject.SetActive(false);
		}
	}

}
