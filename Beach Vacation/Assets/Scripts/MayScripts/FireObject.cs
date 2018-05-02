using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireObject : MonoBehaviour {

    public GameObject fireFlame;
    public Light light;

	// Use this for initialization
	void Start () {
        //fireFlame = this.gameObject;
        light = GetComponent<Light>();
        fireFlame = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        
        
	}
}
