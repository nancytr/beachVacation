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

        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f)
        {
            intensityMultiplier = 0;
            isNight = true;
        }

        else if (currentTimeOfDay <= 0.25f)
        {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        }

        else if (currentTimeOfDay >= 0.73f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
        }

        else
        {
            isNight = false;
        }

        sun.intensity = sunInitialIntensity * intensityMultiplier;

        // Increments the new day. Runs once during update.
        if (currentTimeOfDay >= 0.25f && currentTimeOfDay <= 0.30f)
        {
            
            if (!isNewDay)
            {
                Debug.Log("new day!");
                daysController.NewDay();
                isNewDay = true;
            }
        }

        if (currentTimeOfDay > 0.30f && currentTimeOfDay <= 0.50f)
        {
            isNewDay = false;
        }
    }
}
