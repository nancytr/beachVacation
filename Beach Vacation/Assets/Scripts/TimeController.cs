using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour {

    [SerializeField] private Light sun;
    [SerializeField] private  float secondsInFullDay = 120f;
    [SerializeField] private DaysController daysController;

    

    [Range(0, 1)] [SerializeField] public float currentTimeOfDay = 0;
    private float timeMultiplier = 1f;
    private float sunInitialIntensity;
    public bool isNight;
    public bool isNewDay = false;

    public float sunRise = 0.23f;
    public float sunSet = 0.75f;

    void Start()
    {

        sunInitialIntensity = sun.intensity;
    }

    void Update()
    {
        UpdateSun();

        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;

        // When day ends, restart day
        if(currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
        }
    }

    void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

        float intensityMultiplier = 1;

        if (currentTimeOfDay <= sunRise || currentTimeOfDay >= sunSet)
        {
            intensityMultiplier = 0;
            isNight = true;

        }

        else if (currentTimeOfDay <= sunRise + 0.02f)
        {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        }

        else if (currentTimeOfDay >= sunSet - 0.02f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
        }

        else
        {
            isNight = false;
        }

        sun.intensity = sunInitialIntensity * intensityMultiplier;

        // Increments the new day. Runs once during update.
        if (currentTimeOfDay >= sunRise + 0.02f && currentTimeOfDay <= (sunRise + 0.02f + 0.05f))
        {
            
            if (!isNewDay)
            {
                Debug.Log("new day!");
                daysController.NewDay();
                isNewDay = true;
            }
        }

        if (currentTimeOfDay > 0.90f && currentTimeOfDay <= 1f)
        {
            isNewDay = false;
        }
    }
}
