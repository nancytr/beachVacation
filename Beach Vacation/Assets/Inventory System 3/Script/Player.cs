using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public MusicControl musicSystem;
    public FirstPersonController fpsController;

    public Slider healthSlider;
    public int maxHealth;
    public int healthFallRate;

    //For triggering low health audio
    public int isHurt;
    private bool hurtAudioPlayed;
    private float healthLow;

    public Slider thirstSlider;
    public int maxThirst;
    public int thirstFallRate;

    public Slider hungerSlider;
    public int maxHunger;
    public int hungerFallRate;

    public Slider staminaSlider;
    public int normMaxStamina;
    public float fatMaxStamina;
    private int staminaFallRate;
    public int staminaFallMult;
    private int staminaRegainRate;
    public int staminaRegainMult;



    public Slider fatigueSlider;
    public float maxFatigue;
    public float fatigueFallRate;

    public bool fatStage1 = true;
    public bool fatStage2 = true;
    public bool fatStage3 = true;

    private bool heartbeat  = false;
    public bool isDead = false;
    public CanvasGroup deathCanvas;
    private bool restartButtonActive;


    [Header("Temperature Settings")]
    //public float freezingTemp;
    //public float currentTemp;
    //public float normalTemp;
    //public float heatTemp;
    //public Text tempNumber;
    //public Image tempBG;

    private CharacterController charController;
    private FirstPersonController playerController;

    void Start()
    {
        fatigueSlider.maxValue = maxFatigue;
        fatigueSlider.value = maxFatigue;

        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;

        thirstSlider.maxValue = maxThirst;
        thirstSlider.value = maxThirst;

        hungerSlider.maxValue = maxHunger;
        hungerSlider.value = maxHunger;

        staminaSlider.maxValue = normMaxStamina;
        staminaSlider.value = normMaxStamina;

        staminaFallRate = 1;
        staminaRegainRate = 1;

        charController = GetComponent<CharacterController>();
        playerController = GetComponent<FirstPersonController>();
    }

    //void UpdateTemp()
    //{
    //    tempNumber.text = currentTemp.ToString("00.0");
    //}

    void Update()
    {

        // Fatigue Section
        if (fatigueSlider.value <= 60 && fatStage1)
        {
            fatMaxStamina = 80;
            staminaSlider.value = fatMaxStamina;
            fatStage1 = false;
        }

        else if (fatigueSlider.value <= 40 && fatStage2)
        {
            fatMaxStamina = 60;
            staminaSlider.value = fatMaxStamina;
            fatStage2 = false;
        }

        else if (fatigueSlider.value <= 20 && fatStage3)
        {
            fatMaxStamina = 20;
            staminaSlider.value = fatMaxStamina;
            fatStage3 = false;
        }

        if (fatigueSlider.value >= 0)
        {
            fatigueSlider.value -= Time.deltaTime * fatigueFallRate;
        }

        else if (fatigueSlider.value <= 0)
        {
            fatigueSlider.value = 0;
        }

        else if (fatigueSlider.value >= maxFatigue)
        {
            fatigueSlider.value = maxFatigue;
        }

        /*
        //Temperature Section
        if (currentTemp <= freezingTemp)
        {
            tempBG.color = Color.blue;
            UpdateTemp();
        }

        else if (currentTemp >= heatTemp - 0.1)
        {
            tempBG.color = Color.red;
            UpdateTemp();
        }

        else
        {
            tempBG.color = Color.green;
            UpdateTemp();
        }
        */


        // Health Controller

        // Makes health fall fastest. Health and Thirst bars are at zero.
        if (hungerSlider.value <= 0 && (thirstSlider.value <= 0))
        {
            healthSlider.value -= Time.deltaTime / healthFallRate * 2;
        }

        else if (hungerSlider.value <= 0 || thirstSlider.value <= 0) //|| currentTemp <= freezingTemp || currentTemp >= heatTemp)
        {
            healthSlider.value -= Time.deltaTime / healthFallRate;
        }

        if (healthSlider.value <= 0 && !isDead)
        {
            Invoke ("CharacterDeath", 0f);
        }

        // Checks if character is hurt enough to trigger hurting audio

        healthLow = maxHealth * .3f;

        if (healthSlider.value <= healthLow && !heartbeat && !isDead)
        {
            Invoke ("PlayHeartbeat", 0f);
        }
        else if (healthSlider.value > healthLow && heartbeat && !isDead)
        {
            Invoke ("StopHeartbeat", 0f);
        }

        // Hunger Controller

        // Decrease hunger if player still has food in belly
        if (hungerSlider.value >= 0)
        {
            hungerSlider.value -= Time.deltaTime / hungerFallRate;

        }

        // Keep hunger at 0 if player has empty belleh
        else if (hungerSlider.value <= 0)
        {
            hungerSlider.value = 0;
        }

        // Keep hunger at max value if player is overeating
        else if (hungerSlider.value >= maxHunger)
        {
            hungerSlider.value = maxHunger;
        }


        // Thirst Controller

        // Decrease thirst if player still got liquid in belly
        if (thirstSlider.value >= 0)
        {
            thirstSlider.value -= Time.deltaTime / thirstFallRate;

        }

        // Keep thirst at 0 if player is a thirsty boi
        else if (thirstSlider.value <= 0)
        {
            thirstSlider.value = 0;
        }

        // Keep thirst at max value if player been over-drinkin
        else if (thirstSlider.value >= maxThirst)
        {
            thirstSlider.value = maxThirst;
        }

        // STAMINA CONTROL SECTION

        // If player is moving and sprinting, lose some stamina
        if (charController.velocity.magnitude > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            staminaSlider.value -= Time.deltaTime / staminaFallRate * staminaFallMult;

            // and also gain some heat ;)
            //if (staminaSlider.value > 0)
            //{
            //    currentTemp += Time.deltaTime / 5;
            //}
        }

        // if player is moving but not sprinting, regain some stamina
        else
        {
            staminaSlider.value += Time.deltaTime / staminaRegainRate * staminaRegainMult;

            //if (currentTemp >= normalTemp)
            //{
            //    currentTemp -= Time.deltaTime / 10;
            //}
        }

        // This prevents stamina from going over 100%
        if (staminaSlider.value >= fatMaxStamina)
        {
            staminaSlider.value = fatMaxStamina;
        }

        // This forces player to walk when out of stamina, and also prevents stamina from going into negatives
        else if (staminaSlider.value <= 0)
        {
            staminaSlider.value = 0;
            playerController.m_RunSpeed = playerController.m_WalkSpeed;
        }

        // Player is able to run again when stamina is greater than zero
        else if (staminaSlider.value >= 0)
        {
            playerController.m_RunSpeed = playerController.m_RunSpeedNorm;
        }
        
        if (isDead)
        {
            restartButtonActive = true;
            deathCanvas.alpha = 1f;
        }

        if (restartButtonActive && Input.GetKeyDown(KeyCode.Return))
        {
            isDead = false;
            SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
        }
    }

    void CharacterDeath()
    {
        // DO SOMETHING HERE! ded
        musicSystem.isDeadMusic();
        isDead = true;

        FMOD.Studio.Bus playerBus = FMODUnity.RuntimeManager.GetBus("bus:/");
        playerBus.stopAllEvents(FMOD.Studio.STOP_MODE.IMMEDIATE);

        fpsController.enabled = false;
    }

    void PlayHeartbeat()
    {
        musicSystem.isLowHealthMusic();
        heartbeat = true;
    }

    void StopHeartbeat()
    {
        musicSystem.isNormalHealth();
        heartbeat = false;
    }


}
