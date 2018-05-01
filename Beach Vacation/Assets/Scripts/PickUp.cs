// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PickUp : MonoBehaviour{
// 	public GameObject item;
// 	public GameObject tempParent;
// 	public Transform guide;
    



// 	// Update is called once per frame
// 	void Start(){
// 		item.GetComponent<Rigidbody>().useGravity = true;
// 	}
// 	// void Update () {
//     //     Vector3 plyr = new Vector3(playerChar.transform.position.x, playerChar.transform.position.y, playerChar.transform.position.z);

// 	// }

// 	// WHEN MOUSE HELD DOWN, GRAVITY TURNS OFF AND CAMERA MOVES TO SEE OBJECT
// 	void OnMouseDown ()
// 	{
// 			item.GetComponent<Rigidbody>().useGravity = false;				//turns off gravity
// 			item.GetComponent<Rigidbody>().isKinematic = true;			// finds position of gameobject
// 			// item.transform.position = guide.transform.position;
//             item.transform.position = guide.transform.position;
// 			item.transform.rotation = guide.transform.rotation;
// 			item.transform.parent = tempParent.transform;
// 			// item.transform.parent = GameObject.Find("FPSController").transform;				//finds position of camera and fps controller
// 			// item.transform.parent = GameObject.Find("FirstPersonCharacter").transform;  // ^^ but this line more inportant

// 	}
// 	// MAKES OBJECT FALL BACK DOWN WHEN LET GO OF MOUSE
// 	void OnMouseUp ()
// 	{
// 		item.GetComponent<Rigidbody>().useGravity = true;				//turns off gravity
// 		item.GetComponent<Rigidbody>().isKinematic = false;
// 		item.transform.parent = null;
// 		item.transform.position = guide.transform.position;
// 	}

// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class PickUp : MonoBehaviour {


    float throwForce = 600;

    public bool canHold = true;
    public GameObject item;
    private GameObject tempParent;
    private Transform guide;
    public bool isHolding = false;
    float distance;

 // Use this for initialization
//  void Start () {
//     guide = GameObject.FindWithTag("Guide").transform;
//  }

 // Update is called once per frame
 
 void Start () {
    FirstPersonController temp;
    temp = FindObjectOfType<FirstPersonController>();
    tempParent = temp.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
    guide = tempParent.transform;
}
 void Update () {

        distance = Vector3.Distance(item.transform.position, guide.transform.position);

        if (isHolding==true)
        {

            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().detectCollisions = true;
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.transform.parent = tempParent.transform;
            item.transform.position = guide.transform.position;
            // if (Input.GetMouseButtonDown(1))
            // {
            //     Debug.Log("Trying to throw");
            //     item.GetComponent<Rigidbody>().AddForce(guide.transform.forward * throwForce);
            //     isHolding = false;
            // }
        }
        else
        {
            item.GetComponent<Rigidbody>().useGravity = true;
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.transform.parent = null;
        }
 }

    void OnMouseDown()

    {
        if (distance <= 2.5)
        {
            isHolding = true;
            //guide.transform.position = item.transform.position;
        }
    }
    void OnMouseUp()
    {
        isHolding = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isHolding = false;
    }

}
