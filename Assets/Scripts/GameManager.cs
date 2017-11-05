using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private static GameManager instance;
	public static GameManager Instance { get { return instance; } }
	[SerializeField] private int maxHealth;
	private int health;
	
	public int MaxHealth { get{ return maxHealth; } }

	void Awake(){
		if (instance != null && instance != this){
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
	}

	void Start () {
		health = maxHealth;
	}
	
	void Update () {
		
	}

	public void SubtractHealth(int damage){

	}
}
