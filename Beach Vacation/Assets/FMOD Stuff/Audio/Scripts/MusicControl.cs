using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicControl : MonoBehaviour {

	// Audio variables
    [FMODUnity.EventRef]
    public string music = "event:/Music/Music";
	FMOD.Studio.EventInstance musicEv;

	// Use this for initialization
	void Start () {
		musicEv = FMODUnity.RuntimeManager.CreateInstance(music);

		musicEv.start();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
