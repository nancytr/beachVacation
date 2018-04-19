using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour {

	// Audio variables
    [FMODUnity.EventRef]
    public string music = "event:/Music/Music";
	FMOD.Studio.EventInstance musicEv;

	// Use this for initialization
	void Start () {
		musicEv = FMODUnity.RuntimeManager.CreateInstance(music);

		musicEv.start();
	}
	
	public void isNightMusic()
	{
		musicEv.setParameterValue("isNight", 1f);
		musicEv.setParameterValue("isDay", 0f);
	}

	public void isDayMusic()
	{
		musicEv.setParameterValue("isDay", 1f);
		musicEv.setParameterValue("isNight", 0f);
	}

	public void isLowHealthMusic()
	{
		musicEv.setParameterValue("isLowHealth", 1f);
	}

	public void isNormalHealth()
	{
		musicEv.setParameterValue("isLowHealth", 0f);
	}
	
	public void isDeadMusic()
	{
		musicEv.setParameterValue("isDead", 1f);
	}
}
