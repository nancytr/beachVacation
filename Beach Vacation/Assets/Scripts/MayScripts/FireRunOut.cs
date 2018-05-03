using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRunOut : MonoBehaviour {

    [SerializeField] private FireObject fireObject;
    [SerializeField] private LightSafety lightSafety;
    private float lightSpeed = 0.15f;
    public int flameDuration = 45;

	// Use this for initialization
	void Start () {
        //lightSafety.nearFire = true;
	}
	
	// Update is called once per frame
	void Update () {
        //StartCoroutine(FireBurningOut());
        fireObject.light.intensity -= lightSpeed * Time.deltaTime;
        if (fireObject.light.intensity <= 2)
        {

            fireObject.fireFlame.SetActive(false);
            fireObject.light.enabled = false;
            lightSafety.nearFire = false;
        }
    }

/*
    IEnumerator FireBurningOut()
    {
        //yield return new WaitForSeconds(flameDuration);
        fireObject.fireFlame.SetActive(false);
        fireObject.light.enabled = false;
    }
*/

    public void increaseFire()
    {
        if (fireObject.light.intensity <= 5)
        {
            fireObject.light.intensity += 3;
        }
        else
        {
            fireObject.light.intensity = 8;
        }
        //flameDuration += 20;
    }
}
