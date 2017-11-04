using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	[SerializeField] private float moveSpeed;

	public float MoveSpeed {
		get{
			return moveSpeed;
		}
	}

	void Start () {
		
	}
	
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "ObstacleDestroyer"){
			FindObjectOfType<ObstacleController>().DestoryObstacle(this);
		}
	}
}
