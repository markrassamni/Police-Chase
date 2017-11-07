using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private static GameManager instance;
	public static GameManager Instance { get { return instance; } }
	[SerializeField] private Sprite[] heartSprites;
	[SerializeField] private Image heartImage;
	[SerializeField] private GameObject pausePanel;
	[SerializeField] private GameObject endPanel;
	[SerializeField] private Text winLoseText;
	[SerializeField] private Text tipText;
	[SerializeField] private GameObject criminalPrefab;
	private const int maxHealth = 3;
	private int currentHealth;
	private bool gameOver;
	private bool paused;
	private const float timeForEndPanel = .7f;
	private const float criminalSpawnTime = 3f;
	private bool gameWon = false;
	
	public int MaxHealth { get{ return maxHealth; } }
	public bool GameOver { get{ return gameOver; } }
	public bool Paused { get { return Paused; } }
	public bool GameWon { get { return gameWon; } }

	void Awake(){
		if (instance != null && instance != this){
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
	}

	IEnumerator Start () {
		currentHealth = maxHealth;
		heartImage.sprite = heartSprites[currentHealth];
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
				LoseGame();
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
		paused = !paused;
        if(paused){
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
        } else {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
        }
	}

	public void LoseGame(){
		gameOver = true;
		winLoseText.text = "Game Over";
		Invoke("ShowGameOverPanel", timeForEndPanel);
	}

	public void ShowGameOverPanel(){
		// Show after set time, or when car leaves screen, whichever comes first
		gameOver = true;
		endPanel.SetActive(true);
	}

	public void SetTipText(string tip){
		tipText.gameObject.SetActive(true);
		tipText.text = tip;
	}

	public void WinGame(){
		gameWon = true;
		winLoseText.text = "You Win!";
		Invoke("ShowGameOverPanel", timeForEndPanel);
	}

	private void SpawnCriminal(){
		Criminal criminal = criminalPrefab.GetComponent<Criminal>();
		Transform spawnPoint = criminal.SpawnPoints[Random.Range(0, criminal.SpawnPoints.Length)];
		Instantiate(criminalPrefab, new Vector3(spawnPoint.position.x, spawnPoint.position.y, criminalPrefab.transform.position.z), criminalPrefab.transform.rotation);
	}
}
