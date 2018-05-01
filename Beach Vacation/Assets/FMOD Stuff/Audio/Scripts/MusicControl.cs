using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour {

	// Audio variables
    [FMODUnity.EventRef]
    public string music = "event:/Music/Music";
	FMOD.Studio.EventInstance musicEv;
	[FMODUnity.EventRef]
    public string lowHealthSound = "event:/Hurt";
	FMOD.Studio.EventInstance lowHealth;
	[FMODUnity.EventRef]
    public string death = "event:/Death";

	

	// Use this for initialization
	void Start () {
		musicEv = FMODUnity.RuntimeManager.CreateInstance(music);
		lowHealth = FMODUnity.RuntimeManager.CreateInstance(lowHealthSound);

		musicEv.start();
	}
	
	public void isNightMusic()
	{
		musicEv.setParameterValue("isNight", 1f);
	}

	public void isDayMusic()
	{
		musicEv.setParameterValue("isNight", 0f);
	}

	public void isLowHealthMusic()
	{
		// musicEv.setParameterValue("isLowHealth", 1f);
		lowHealth.start();
	}

	public void isNormalHealth()
	{
		// musicEv.setParameterValue("isLowHealth", 0f);
		lowHealth.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
	}
	
	public void isDeadMusic()
	{
		FMODUnity.RuntimeManager.PlayOneShot(death);
	}
}
