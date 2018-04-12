using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DaysController : MonoBehaviour
{

    // This script stores the number of days integer,
    // and updates the text on the HUD to display the number of days.


    [SerializeField] private Text dayText;
    private int dayNumber = 1;
    public void NewDay()
    {
        dayNumber += 1;
        dayText.text = dayNumber.ToString();

    }
}