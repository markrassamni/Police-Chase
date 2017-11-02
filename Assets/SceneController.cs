using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public void LoadGame(){
		SceneManager.LoadScene("Game");
	}

	public void LoadMenu(){
		SceneManager.LoadScene("MainMenu");
	}

	public void LoadOptions(){
		SceneManager.LoadScene("Options");
	}

	public void LoadCredits(){
		SceneManager.LoadScene("Credits");
	}
}
