﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

	[SerializeField] private float minSpawnDelay;
	[SerializeField] private float maxSpawnDelay;
	[SerializeField] private Obstacle[] obstaclePrefabs;
	private List<Obstacle> obstacles = new List<Obstacle>();

	IEnumerator Start () {
		yield return new WaitForSeconds(1.5f);
		StartCoroutine(Spawn());
	}
	
	void Update () {
		MoveObstacles();
	}

	private IEnumerator Spawn(){
		Obstacle randomObstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
		Vector3 randomSpawnPoint = randomObstacle.SpawnPoints[Random.Range(0, randomObstacle.SpawnPoints.Length)].position;
		Obstacle obstacle = Instantiate(randomObstacle, randomSpawnPoint, Quaternion.identity, transform);
		obstacles.Add(obstacle);
		yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
		StartCoroutine(Spawn());
	}

	private void MoveObstacles(){
		foreach(Obstacle obstacle in obstacles){
			obstacle.Move();
		}
	}

	public void DestroyObstacle(Obstacle obstacle){
		obstacles.Remove(obstacle);
		Destroy(obstacle.gameObject);
	}
}
