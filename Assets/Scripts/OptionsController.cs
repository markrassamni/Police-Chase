using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

	[SerializeField] private Slider volumeSlider;

	void Start () {
		volumeSlider.value = PlayerPrefsManager.GetVolume();
	}
	
	void Update () {
		PlayerPrefsManager.SetVolume(volumeSlider.value);
		SoundController.Instance.SetVolume(volumeSlider.value);
	}
}
