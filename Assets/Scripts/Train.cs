using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Train : Obstacle {
	[SerializeField] private bool topTrain;
	[SerializeField] private bool bottomTrain;
	[SerializeField] private Obstacle railPrefab;
	[SerializeField] private float minSpawnTime;
	[SerializeField] private float maxSpawnTime = 1.5f;
	[SerializeField] private GameObject[] wagons;

	private bool startedMoving;

	IEnumerator Start () {
		if(topTrain && bottomTrain){
			if (name == "TrainBottom(Clone)"){
				topTrain = false;
			} else if (name == "TrainTop(Clone)"){
				bottomTrain = false;
			} else {
				Debug.LogWarning("Unable to decide if top or bottom train.");
			}
		}
		if (!topTrain && !bottomTrain){
			if (name == "TrainBottom(Clone)"){
				bottomTrain = true;
			} else if (name == "TrainTop(Clone)"){
				topTrain = true;
			} else {
				Debug.LogWarning("Unable to decide if top or bottom train.");
			}
		}
		Assert.AreNotEqual(topTrain, bottomTrain);
		SpawnRail();
		SpawnWagons();
		yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
		startedMoving = true;
	}

	private void SpawnRail(){
		ObstacleController obstacleController = FindObjectOfType<ObstacleController>();
		Obstacle rail = Instantiate(railPrefab, new Vector3(transform.position.x, 0f, transform.position.z), railPrefab.transform.rotation, obstacleController.transform);
		transform.parent = rail.transform;
		obstacleController.AddObstacle(rail);
	}

	private void SpawnWagons(){
		int numberOfWagons = Random.Range(0, wagons.Length+1);
		for (int i=0; i<numberOfWagons; i++){
			wagons[i].SetActive(true);
		}
	}

	override public void Move(){
		if (startedMoving){
			if(topTrain){
				transform.Translate(Vector3.down * MoveSpeed * Time.deltaTime);
			} else if (bottomTrain) {
				transform.Translate(Vector3.up * MoveSpeed * Time.deltaTime);
			}
		}
	}
}
