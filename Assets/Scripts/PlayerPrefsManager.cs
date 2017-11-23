using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

	private const string volumeKey = "master_volume";
	private const float defaultVolume = 0.8f;

	public static void SetVolume(float volume){
		if (volume >= 0f && volume <= 1f){
			PlayerPrefs.SetFloat(volumeKey, volume);
		} else {
			Debug.LogError("Volume out of range");
		}
	}

	public static float GetVolume(){
		return PlayerPrefs.GetFloat(volumeKey, defaultVolume);
	}


}
