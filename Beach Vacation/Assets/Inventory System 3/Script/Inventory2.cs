using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory2 : MonoBehaviour {

	public bool inventory2Enabled;
	public GameObject inventory2;
	public GameObject itemManager;
	private Transform[] slot2;
	public GameObject slotHolder;
	private bool pickedUpItem;
    private bool isMouseDisabled;
	//public GameObject disableManager;
	[SerializeField] private DisableManager disableManager;

    Color brown = new Color(146, 110, 80);
    Color white = new Color(255, 255, 255);


	public void Start()
	{
		GetAllSlots();
		disableManager = GameObject.FindGameObjectWithTag("DisableController").GetComponent<DisableManager>();
        isMouseDisabled = false;
		

	}

	public void Update()
	{
        if (Input.GetKeyDown(KeyCode.I) && !isMouseDisabled)
        {
                disableManager.DisablePlayer();
                inventory2Enabled = !inventory2Enabled;
                //disableManager.DisablePlayer();
                isMouseDisabled = true;
        }

        else if (Input.GetKeyDown(KeyCode.I) && isMouseDisabled)
        {
            disableManager.EnablePlayer();
            inventory2Enabled = !inventory2Enabled;
            isMouseDisabled = false;
        }

		if (inventory2Enabled)
		{
				inventory2.GetComponent<CanvasGroup>().alpha = 1f; 
     			inventory2.GetComponent<CanvasGroup>().blocksRaycasts = false;
				
				// inventory2.SetActive(true);
				//disableManager.GetComponent<DisableManager>().DisablePlayer();
				//disableManager.DisablePlayer();
		}
		else
				inventory2.GetComponent<CanvasGroup>().alpha = 0f; 
     			inventory2.GetComponent<CanvasGroup>().blocksRaycasts = true;
				
				// inventory2.SetActive(false);
				//disableManager.GetComponent<DisableManager>().EnablePlayer();
				//disableManager.EnablePlayer();


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


	public void OnTriggerStay(Collider other)
	{
        // logic for picking up item by walking over
		if (other.tag == "Item")
		{
            if (Input.GetKeyDown(KeyCode.E))
            {
               print("about to add");
			    AddItem(other.gameObject);
				print("added");
            }
			//AddItem(other.gameObject);
			
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
                //slot2[i].GetComponent<RawImage>().color = white;

				item.transform.parent = itemManager.transform;     //actually add to itemdatabase
				item.transform.position = itemManager.transform.position;

				// Destroy(item);

				// if (item.GetComponent<MeshRenderer>())
				// 	item.GetComponent<MeshRenderer>().enabled = false;

				// Destroy (item.GetComponent<Rigidbody>());

				item.SetActive(false);

			}
		}

	}

	public void GetAllSlots()
	{
		slot2 = new Transform[12];
		for (int i = 0; i < 12; i++)
		{
			slot2[i] = slotHolder.transform.GetChild(i);
			// print (slot2[i]);
			// print(slot2[i]);
			// print(slot2[i].gameObject.name);
		}
	}

}
