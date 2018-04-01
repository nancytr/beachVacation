﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SleepController : MonoBehaviour
{
    [SerializeField] private GameObject sleepUI;
    [SerializeField] private Slider sleepSlider;
    [SerializeField] private Text sleepNumber;

    [SerializeField] private float hourlyRegen;
    // DISABLE MANAGER
    [SerializeField] private DisableManager disableManager;


    void Start()
    {
        disableManager = GameObject.FindGameObjectWithTag("DisableController").GetComponent<DisableManager>();
    }

    public void EnableSleepUI()
    {
        sleepUI.SetActive(true);
        disableManager.DisablePlayer();
    }

    public void UpdateSlider()
    {
        sleepNumber.text = sleepSlider.value.ToString("0");
    }

    public void SleepBtn(PlayerVitals playerVitals)
    {

        playerVitals.fatigueSlider.value = sleepSlider.value * hourlyRegen;
        playerVitals.fatMaxStamina = playerVitals.fatigueSlider.value;
        playerVitals.staminaSlider.value = playerVitals.normMaxStamina;
        playerVitals.fatStage1 = true;
        playerVitals.fatStage2 = true;
        playerVitals.fatStage3 = true;
        sleepSlider.value = 1;
        disableManager.EnablePlayer();
        sleepUI.SetActive(false);
    }
}
