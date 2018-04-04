using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSafety : MonoBehaviour {

    public bool nearFire;

	// Use this for initialization
	void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {      
            nearFire = true;
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
