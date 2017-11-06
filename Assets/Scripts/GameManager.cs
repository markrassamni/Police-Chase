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
	[SerializeField] private GameObject gameOverPanel;
	private const int maxHealth = 3;
	private int currentHealth;
	private bool gameOver;
	private bool paused;
	private const float timeForLosePanel = 1.5f;
	
	public int MaxHealth { get{ return maxHealth; } }
	public bool GameOver { get{ return gameOver; } }
	public bool Paused { get { return Paused; } }

	void Awake(){
		if (instance != null && instance != this){
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
	}

	void Start () {
		currentHealth = maxHealth;
		heartImage.sprite = heartSprites[currentHealth];
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)){
			Pause();
		}
	}

	public void SubtractHealth(int damage){
		if (currentHealth - damage > 0){
			currentHealth -= damage;
		} else {
			currentHealth = 0;
			EndGame();
		}
		heartImage.sprite = heartSprites[currentHealth];
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

	private void Pause(){
		paused = !paused;
        if(paused){
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
        } else {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
        }
	}

	private void EndGame(){
		gameOver = true;
		Invoke("ShowGameOverPanel", timeForLosePanel);
	}

	public void ShowGameOverPanel(){
		// Show after set time, or when car leaves screen, whichever comes first
		gameOverPanel.SetActive(true);
	}
}
