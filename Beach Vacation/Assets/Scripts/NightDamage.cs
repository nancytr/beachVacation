using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightDamage : MonoBehaviour {

    [SerializeField] private TimeController timeController;
    [SerializeField] private Player playerVitals;
    [SerializeField] private LightSafety lightSafety;

    [FMODUnity.EventRef]
    public string nightHurt;

    public float damageRate;

    void Start()
    {
        InvokeRepeating("IncrementalDamage", 2.0f, 3.0f);
    }


    void IncrementalDamage()
    {
        if (timeController.isNight && !lightSafety.nearFire)
        {
            playerVitals.healthSlider.value -= 20f;
            FMODUnity.RuntimeManager.PlayOneShot(nightHurt);
        }
    }


}
