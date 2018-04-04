using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightDamage : MonoBehaviour {

    [SerializeField] private TimeController timeController;
    [SerializeField] private PlayerVitals playerVitals;
    [SerializeField] private LightSafety lightSafety;


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
        }
    }


}
