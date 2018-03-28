using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerVitals : MonoBehaviour
{
    public Slider healthSlider;
    public int maxHealth;
    public int healthFallRate;

    public Slider thirstSlider;
    public int maxThirst;
    public int thirstFallRate;

    public Slider hungerSlider;
    public int maxHunger;
    public int hungerFallRate;

    public Slider staminaSlider;
    public int maxStamina;
    private int staminaFallRate;
    public int staminaFallMult;
    private int staminaRegainRate;
    public int staminaRegainMult;

    private CharacterController charController;
    private FirstPersonController playerController;

    void Start()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;

        thirstSlider.maxValue = maxThirst;
        thirstSlider.value = maxThirst;

        hungerSlider.maxValue = maxHunger;
        hungerSlider.value = maxHunger;

        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = maxStamina;

        staminaFallRate = 1;
        staminaRegainRate = 1;

        charController = GetComponent<CharacterController>();
        playerController = GetComponent<FirstPersonController>();
    }

    void Update()
    {
        // Health Controller

        // Makes health fall fastest. Health and Thirst bars are at zero.
        if (hungerSlider.value <= 0 && (thirstSlider.value <= 0))
        {
            healthSlider.value -= Time.deltaTime / healthFallRate * 2;
        }

        else if (hungerSlider.value <= 0 || thirstSlider.value <= 0)
        {
            healthSlider.value -= Time.deltaTime / healthFallRate;
        }

        if (healthSlider.value <= 0)
        {
            CharacterDeath();
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
        }

        // if player is moving but not sprinting, regain some stamina
        else
        {
            staminaSlider.value += Time.deltaTime / staminaRegainRate * staminaRegainMult;
        }

        // This prevents stamina from going over 100%
        if (staminaSlider.value >= maxStamina)
        {
            staminaSlider.value = maxStamina;
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
    }

    void CharacterDeath()
    {
        // DO SOMETHING HERE!
    }
}
