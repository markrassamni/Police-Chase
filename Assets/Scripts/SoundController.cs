using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : Singleton<SoundController> {

	[SerializeField] private AudioClip menuMusic;
	[SerializeField] private AudioClip gameMusic;

	override protected void Awake(){
		base.Awake();
		DontDestroyOnLoad(this);
	}

	void Start () {
		
	}
	
	void Update () {
		
	}
}
