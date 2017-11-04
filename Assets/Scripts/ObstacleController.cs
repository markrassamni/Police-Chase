﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

	[SerializeField] private float minSpawnDelay;
	[SerializeField] private float maxSpawnDelay;
	[SerializeField] private Obstacle[] obstaclePrefabs;
	[SerializeField] private Transform[] spawnPoints;
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
		Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
		Obstacle obstacle = Instantiate(randomObstacle, randomSpawnPoint) as Obstacle;
		obstacles.Add(obstacle);
		yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
		StartCoroutine(Spawn());
	}

	private void MoveObstacles(){
		foreach(Obstacle obstacle in obstacles){
			float moveSpeed = obstacle.MoveSpeed;
			obstacle.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
		}
	}

	public void DestroyObstacle(Obstacle obstacle){
		obstacles.Remove(obstacle);
		Destroy(obstacle.gameObject);
	}
}
