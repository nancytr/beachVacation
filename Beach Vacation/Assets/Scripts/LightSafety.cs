using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSafety : MonoBehaviour {

    public bool nearFire;
    [SerializeField] ItemProperties itemProperties;
    [SerializeField] FireRunOut fireRunout;

	// Use this for initialization
	void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {      
            nearFire = true;
        }

        if (collision.gameObject.tag == "Item")
        {
            if (itemProperties.itemName == ("Wood"))
            {
                
                Destroy(collision.gameObject);
                fireRunout.increaseFire();
            }
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            nearFire = false;
        }
    }
}
