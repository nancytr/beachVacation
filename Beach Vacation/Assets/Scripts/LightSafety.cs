using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSafety : MonoBehaviour {

    public bool nearFire;
    [SerializeField] ItemProperties itemProperties;
    [SerializeField] FireRunOut fireRunout;

    private void Start()
    {
        this.GetComponent<ItemProperties> ();
    }

    // Use this for initialization
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            nearFire = true;
            
            
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Log")
        {
            Destroy(other.gameObject);
            fireRunout.increaseFire();

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
