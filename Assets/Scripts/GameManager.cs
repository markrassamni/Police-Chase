using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager> {
	
	[SerializeField] private Sprite[] heartSprites;
	[SerializeField] private Image heartImage;
	[SerializeField] private GameObject pausePanel;
	[SerializeField] private GameObject endPanel;
	[SerializeField] private Text winLoseText;
	[SerializeField] private Text tipText;
	[SerializeField] private GameObject criminalPrefab;
	private SceneController sceneController;
	private const int maxHealth = 3;
	private int currentHealth;
	private bool gameOver;
	private bool paused;
	private const float timeForEndPanel = .7f;
	private const float criminalSpawnTime = 45f;
	private bool gameWon = false;
	
	public int MaxHealth { get{ return maxHealth; } }
	public bool GameOver { get{ return gameOver; } }
	public bool Paused { get { return Paused; } }
	public bool GameWon { get { return gameWon; } }

	IEnumerator Start () {
		currentHealth = maxHealth;
		heartImage.sprite = heartSprites[currentHealth];
		sceneController = FindObjectOfType<SceneController>();
		yield return new WaitForSeconds(criminalSpawnTime);
		SpawnCriminal();
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) && !gameOver && !gameWon){
			Pause();
		}
	}

	public void SubtractHealth(int damage){
		if (!gameWon){
			if (currentHealth - damage > 0){
				currentHealth -= damage;
			} else {
				currentHealth = 0;
				StartCoroutine(LoseGame());
			}
			heartImage.sprite = heartSprites[currentHealth];
		}
	}

	public bool AddHealth(){
		if (currentHealth < maxHealth){
			currentHealth += 1;
			heartImage.sprite = heartSprites[currentHealth];
			return true;
		} else {
			return false;
		}
	}

	public void Pause(){
		if(!gameOver) {
			paused = !paused;
			if(paused){
				SoundController.Instance.Pause();
				Time.timeScale = 0f;
				pausePanel.SetActive(true);
			} else {
				SoundController.Instance.UnPause();
				Time.timeScale = 1f;
				pausePanel.SetActive(false);
			}
		}
	}

	public void GoToMenu(){
		if(paused){
			Pause();
		}
		sceneController.LoadMenu();
	}

	public IEnumerator LoseGame(){
		gameOver = true;
		winLoseText.text = "Game Over";
		yield return new WaitForSeconds(timeForEndPanel);
		ShowGameLostPanel();
	}

	public void ShowGameLostPanel(){
		// After set time, or when car leaves screen, whichever comes first
		if(!endPanel.activeSelf){
			gameOver = true;
			endPanel.SetActive(true);
			SoundController.Instance.PlayGameOver();
		}
	}

	public void SetTipText(string tip){
		tipText.text = tip;
	}

	public IEnumerator WinGame(){
		gameWon = true;
		tipText.enabled = false;
		winLoseText.text = "You Win!";
		SoundController.Instance.PlayGameWon();
		endPanel.SetActive(true);
		yield return new WaitForSeconds(timeForEndPanel);
		gameOver = true;
	}

	private void SpawnCriminal(){
		Criminal criminal = criminalPrefab.GetComponent<Criminal>();
		Transform spawnPoint = criminal.SpawnPoints[Random.Range(0, criminal.SpawnPoints.Length)];
		Instantiate(criminalPrefab, new Vector3(spawnPoint.position.x, spawnPoint.position.y, criminalPrefab.transform.position.z), criminalPrefab.transform.rotation);
	}
}
