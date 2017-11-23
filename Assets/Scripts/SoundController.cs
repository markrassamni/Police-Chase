using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : Singleton<SoundController> {

	[SerializeField] private AudioClip menuMusic;
	[SerializeField] private AudioClip gameMusic;
	private AudioSource musicSource;

	override protected void Awake(){
		base.Awake();
		DontDestroyOnLoad(this);
	}

	void Start () {
		musicSource = GetComponent<AudioSource>();
		musicSource.clip = menuMusic;
		musicSource.Play();
	}
	
	void Update () {
		musicSource.volume = .8f; //TODO: Player prefs volume
	}

	public void PlayMenuMusic(){
		musicSource.Stop();
		musicSource.clip = menuMusic;
		musicSource.Play();
	}

	public void PlayGameMusic(){
		musicSource.Stop();
		musicSource.clip = gameMusic;
		musicSource.Play();
	}

}
