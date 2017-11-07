using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Criminal : Obstacle {
	
	void Update () {
		Move();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (!GameManager.Instance.GameOver && !GameManager.Instance.GameWon){
			if(other.tag == "GameOver"){
				GameManager.Instance.LoseGame();
				GameManager.Instance.SetTipText("Tip: Don't let the criminal escape!");
			}
		}
	}
}
