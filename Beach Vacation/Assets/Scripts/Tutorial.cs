using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    private bool tutorialActive = false;


	void Start () 
    {
		
	}
	
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            tutorialActive = !tutorialActive;
            

        }

        if (tutorialActive)
        {
            this.GetComponent<CanvasGroup>().alpha = 1f;
        }
        else
        {
            this.GetComponent<CanvasGroup>().alpha = 0f;
        }
    
    }
}
