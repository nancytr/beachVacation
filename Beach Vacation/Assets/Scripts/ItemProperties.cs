using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProperties : MonoBehaviour {

    [Header("Your Consumables")]
    public string itemName;

    [SerializeField] private bool food;
    [SerializeField] private bool water;
    [SerializeField] private bool health;
    [SerializeField] private bool sleepingBag;

    [SerializeField] private float value;
    [SerializeField] private SleepController sleepController;
    [SerializeField] private TimeController timeController;

    void Start()
    {
        sleepController = GameObject.FindGameObjectWithTag("SleepController").GetComponent<SleepController>();
    }


    //[SerializeField] private PlayerVitals playerVitals;

    public void Interaction(PlayerVitals playerVitals)
    {
        if (food)
        {
            playerVitals.hungerSlider.value += value;
            this.gameObject.SetActive(false);
        }

        else if (water)
        {
            playerVitals.thirstSlider.value += value;
            this.gameObject.SetActive(false);
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
