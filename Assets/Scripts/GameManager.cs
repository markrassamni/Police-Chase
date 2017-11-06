using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private static GameManager instance;
	public static GameManager Instance { get { return instance; } }
	[SerializeField] private Sprite[] heartSprites;
	[SerializeField] private Image heartImage;
	private const int maxHealth = 3;
	private int currentHealth;
	private bool gameOver;
	
	public int MaxHealth { get{ return maxHealth; } }
	public bool GameOver { get{ return gameOver; } }

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
		
	}

	public void SubtractHealth(int damage){
		if (currentHealth - damage > 0){
			currentHealth -= damage;
		} else {
			currentHealth = 0;
			gameOver = true;
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
}
