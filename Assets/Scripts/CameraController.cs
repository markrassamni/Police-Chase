using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	[SerializeField] private GameObject car;
	[SerializeField] private float moveSpeed;
	private Vector3 carPosition;
	private float cameraOffset;

	void Start () {
		
	}
	
	void Update () {
		carPosition = car.transform.position;
		transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
	}
}
