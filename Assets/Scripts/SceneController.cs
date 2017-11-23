using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController> {

	private string previousSceneName;

	override protected void Awake(){
		base.Awake();
		DontDestroyOnLoad(this);
	}

	void Start(){
		SceneManager.sceneLoaded += OnSceneLoaded;
		previousSceneName = SceneManager.GetActiveScene().name;
	}
	
	private void OnSceneLoaded(Scene nextScene, LoadSceneMode mode){
		if(previousSceneName == "Game" && nextScene.name == "MainMenu"){
			SoundController.Instance.PlayMenuMusic();
		} else if (previousSceneName == "MainMenu" && nextScene.name == "Game"){
			SoundController.Instance.PlayGameMusic();
		} else if (previousSceneName == "Options"){
			PlayerPrefs.Save();
		}
		previousSceneName = nextScene.name; 
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
		#else
			Application.Quit();
		#endif
	}
}
