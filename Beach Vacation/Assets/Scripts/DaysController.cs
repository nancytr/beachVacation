using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DaysController : MonoBehaviour
{

    [SerializeField] private TimeController timeController;

    [SerializeField] private Text dayNumber;
    private int num_Days = 1;

    public void NewDay()
    {
        num_Days += 1;
        dayNumber.text = num_Days.ToString();
        timeController.currentTimeOfDay = 0.25f;
    }
}