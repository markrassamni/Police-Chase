using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Train : Obstacle {

	[SerializeField] private bool topTrain;
	[SerializeField] private bool bottomTrain;

	void Start () {
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
	}

	override public void Move(){
		if(topTrain){
			transform.Translate(Vector3.down * MoveSpeed * Time.deltaTime);
		} else if (bottomTrain) {
			transform.Translate(Vector3.up * MoveSpeed * Time.deltaTime);
		}
	}
}
