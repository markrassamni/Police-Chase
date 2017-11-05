using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

	[SerializeField] private float moveSpeed;
	[SerializeField] private Sprite blueSiren;
	[SerializeField] private Sprite redSiren;
	private SpriteRenderer spriteRenderer;
	private const float offsetFromSide = 0.8f;
	private const float minY = -4.2f;
	private const float maxY = 4.2f;
	private const float minX = -7f;
	private const float maxX = 0f;
	private const float sirenTime = .35f;
	
	void Start(){
		spriteRenderer = GetComponent<SpriteRenderer>();
		StartCoroutine(ChangeSirenColor());
	}
	void Update () {
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

	private IEnumerator ChangeSirenColor(){
		yield return new WaitForSeconds(sirenTime);
		if (spriteRenderer.sprite == redSiren){
			spriteRenderer.sprite = blueSiren;
		} else {
			spriteRenderer.sprite = redSiren;
		}
		StartCoroutine(ChangeSirenColor());
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Obstacle"){
			Obstacle obstacle = other.GetComponentInParent<Obstacle>();
			int damage = obstacle.Damage;
		} else if (other.tag == "Train"){
			other.GetComponent<BoxCollider2D>().isTrigger = false;
			Train train = other.GetComponentInParent<Train>();
			int damage = train.Damage;
		}
	}
}
