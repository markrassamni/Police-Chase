using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

	[SerializeField] private float moveSpeed;
	//TODO make min/max consts
	[SerializeField] private float maxY;
	[SerializeField] private float minY;
	[SerializeField] private float minX;
	[SerializeField] private float maxX;
	private float locationOffset = 0f;
	
	void Start () {
		
	}
	
	void Update () {
		HandleUserInput();
	}

	void LateUpdate(){
		MoveCar();
	}

	private void MoveCar(){
		Vector3 lowerBound = Camera.main.ViewportToWorldPoint(Vector3.zero);
		Vector3 upperBound = Camera.main.ViewportToWorldPoint(Vector3.one);
		transform.position = new Vector3(lowerBound.x + locationOffset, transform.position.y, transform.position.z);
	}

	private void HandleUserInput(){
		if (Input.GetKey("left") || Input.GetKey("a")){
			print("left");
		}
		if (Input.GetKey("right") || Input.GetKey("d")){
			print("right");
		}
		if (Input.GetKey("up") || Input.GetKey("w")){
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, maxY, transform.position.z),
				moveSpeed * Time.deltaTime);
		}
		if (Input.GetKey("down") || Input.GetKey("s")){
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, minY, transform.position.z),
				moveSpeed * Time.deltaTime);
		}
	}
}
