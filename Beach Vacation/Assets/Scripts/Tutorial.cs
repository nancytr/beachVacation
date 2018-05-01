using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    private bool tutorialActive;


	void Start () 
    {
		
	}
	
	void Update () 
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            tutorialActive = true;
            this.GetComponent<CanvasGroup>().alpha = 1f;

        }
        else
        {
            tutorialActive = false;
            this.GetComponent<CanvasGroup>().alpha = 0f;
        }
	}
}
