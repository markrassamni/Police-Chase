using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController> {

	override protected void Awake(){
		base.Awake();
		DontDestroyOnLoad(this);
	}

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

	public void LoadTutorial(){
		SceneManager.LoadScene("Tutorial");
	}

	public void ExitGame(){
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#elif UNITY_STANDALONE
			Application.Quit();
		#endif
	}
}
