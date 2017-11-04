﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Obstacle"){
			Obstacle obstacle = other.GetComponentInParent<Obstacle>();
			FindObjectOfType<ObstacleController>().DestroyObstacle(obstacle);
		}
	}
}