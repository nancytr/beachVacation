using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProperties : MonoBehaviour {

    [Header("Your Consumables")]
    public string itemName;

    [SerializeField] private bool food;
    [SerializeField] private bool water;
    [SerializeField] private bool health;
    [SerializeField] public bool craftable;
    [SerializeField] private bool sleepingBag;
    [SerializeField] private bool equippable;

    [SerializeField] private float value;
    [SerializeField] private SleepController sleepController;
    [SerializeField] private TimeController timeController;

    // sound variables
    [FMODUnity.EventRef]
    public string eatingSound;
    public string drinkingSound;

    void Start()
    {
        sleepController = GameObject.FindGameObjectWithTag("SleepController").GetComponent<SleepController>();
    }


    //[SerializeField] private PlayerVitals playerVitals;

    public void Interaction(Player playerVitals)
    {
        if (food)
        {
            playerVitals.hungerSlider.value += value;
            this.gameObject.SetActive(false);

            FMODUnity.RuntimeManager.PlayOneShot(eatingSound);
        }

        else if (water)
        {
            playerVitals.thirstSlider.value += value;
            this.gameObject.SetActive(false);
            FMODUnity.RuntimeManager.PlayOneShot(drinkingSound);
        }

        else if (health)
        {
            playerVitals.healthSlider.value += value;
            this.gameObject.SetActive(false);
        }

        else if (sleepingBag)
        {
            if (timeController.isNight)
            {
                sleepController.EnableSleepUI();
            }
            else
            {
                sleepController.CantSleepUI.SetActive(true);
                StartCoroutine(byeUI());
            }
        }
    }

    IEnumerator byeUI()
     {
        yield return new WaitForSeconds(3);
        sleepController.CantSleepUI.SetActive(false);
     }
    
}
