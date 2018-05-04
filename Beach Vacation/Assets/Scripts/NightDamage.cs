using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightDamage : MonoBehaviour {

    [SerializeField] private TimeController timeController;
    [SerializeField] private Player playerVitals;
    //[SerializeField] private LightSafety lightSafety;

    [FMODUnity.EventRef]
    public string nightHurt;

    public float damageRate;

    void Start()
    {
        InvokeRepeating("IncrementalDamage", 2.0f, 3.0f);
    }


    void IncrementalDamage()
    {
        LightSafety temp;
        temp = FindObjectOfType<LightSafety>();
        // if its nighttime, if player is not near fire and if player is not dead:
        //lightSafety = gameObject.GetComponent<LightSafety>();
        if (timeController.isNight && !temp.nearFire && !playerVitals.isDead)
        {
            
            //Debug.Log(!lightSafety.nearFire);
            playerVitals.healthSlider.value -= 20f;
            FMODUnity.RuntimeManager.PlayOneShot(nightHurt);
            print("i am near a fire?");
            print(temp.nearFire);
        }
    }


}
