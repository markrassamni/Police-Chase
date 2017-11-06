using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour {

	[SerializeField] private float moveSpeed;
	private Vector2 originalOffset;

	void Start () {
		originalOffset = GetComponent<Renderer>().sharedMaterial.GetTextureOffset("_MainTex");
	}
	
	void Update () {
		float newOffsetX = Mathf.Repeat(Time.time * moveSpeed, 1);
		GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", new Vector2(newOffsetX, originalOffset.y));
	}

	void OnDisable(){
		GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", originalOffset);
	}
}
