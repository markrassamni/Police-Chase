using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

	[SerializeField] private float moveSpeed;
	[SerializeField] private float minX;
	[SerializeField] private float maxX;
	private const float offsetFromSide = 0.8f;
	private const float minY = -4.2f;
	private const float maxY = 4.2f;
	
	void Update () {
		minX = Camera.main.ViewportToWorldPoint(Vector3.zero).x + offsetFromSide;
		maxX = Camera.main.transform.position.x - offsetFromSide;
		HandleUserInput();
	}

	private void HandleUserInput(){
		if (Input.GetKey("left") || Input.GetKey("a")){
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(minX, transform.position.y, transform.position.z), moveSpeed * Time.deltaTime);
		}
		if (Input.GetKey("right") || Input.GetKey("d")){
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(maxX, transform.position.y, transform.position.z), moveSpeed * Time.deltaTime);
		}
		if (Input.GetKey("up") || Input.GetKey("w")){
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, maxY, transform.position.z), moveSpeed * Time.deltaTime);
		}
		if (Input.GetKey("down") || Input.GetKey("s")){
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, minY, transform.position.z), moveSpeed * Time.deltaTime);
		}
	}
}
