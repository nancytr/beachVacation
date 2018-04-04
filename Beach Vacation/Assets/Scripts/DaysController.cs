using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DaysController : MonoBehaviour
{


    [SerializeField] private Text dayText;
    private int dayNumber = 1;

    public void NewDay()
    {
        dayNumber += 1;
        dayText.text = dayNumber.ToString();

    }
}