using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Criminal : Obstacle {

	private const float maxY = 4.2f;
	private const float minY = -4.2f;
	private const float verticalMoveSpeed = .3f;
	private float time;

	void Start(){
		time = Random.value / verticalMoveSpeed;
	}
	
	void Update () {
		time += Time.deltaTime;
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

	override public void Move(){
		transform.position = Vector3.MoveTowards(transform.position, new Vector3(-50f, transform.position.y, transform.position.z), MoveSpeed * Time.deltaTime);
		if (!GameManager.Instance.GameWon){
			Vector3 current = transform.position;
			transform.position = Vector3.Lerp(new Vector3(current.x, maxY, current.z), new Vector3(current.x, minY, current.z), Mathf.PingPong(time * verticalMoveSpeed, 1f));
		}
	}
}
