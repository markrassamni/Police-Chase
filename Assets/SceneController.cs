using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	void Start () {
		DontDestroyOnLoad(gameObject);
		SceneManager.LoadScene("MainMenu");
	}
	
	void Update () {
		
	}

	public void LoadGame(){
		SceneManager.LoadScene("Game");
	}
}
