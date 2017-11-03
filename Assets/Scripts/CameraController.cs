using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	[SerializeField] private float moveSpeed;
	
	void Update () {
		transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
	}
}
