using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProperties : MonoBehaviour {

    [Header("Your Consumables")]
    public string itemName;

    [SerializeField] private bool food;
    [SerializeField] private bool water;
    [SerializeField] private bool health;
    [SerializeField] private bool bush;
    [SerializeField] public bool burnable;
    [SerializeField] public bool craftable;
    [SerializeField] private bool sleepingBag;
    [SerializeField] private bool equippable;

    [SerializeField] private float value;
    [SerializeField] private SleepController sleepController;
    [SerializeField] private TimeController timeController;

    // sound variables
    [FMODUnity.EventRef]
    public string eatingSound;
    [FMODUnity.EventRef]
    public string drinkingSound;

    //bush stuff
    [SerializeField] private Transform leaves;

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
            //playerVitals.thirstSlider.value += value;
            //this.gameObject.SetActive(false);
            //FMODUnity.RuntimeManager.PlayOneShot(drinkingSound);
        }

        else if (health)
        {
            playerVitals.healthSlider.value += value;
            this.gameObject.SetActive(false);
        }

        else if (bush)
        {
            //this.gameObject.SetActive(false);
            Vector3 position = new Vector3(0, 0, 0);
            Instantiate(leaves, this.transform.position + new Vector3(0, 0, 0) + position, this.transform.rotation);
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
