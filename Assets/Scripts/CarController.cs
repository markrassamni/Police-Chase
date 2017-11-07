using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

	[SerializeField] private float moveSpeed;
	[SerializeField] private Sprite blueSiren;
	[SerializeField] private Sprite redSiren;
	private const float offsetFromSide = 0.8f;
	private const float minY = -4.2f;
	private const float maxY = 4.2f;
	private const float minX = -7f;
	private const float maxX = 7f;
	private const float sirenTime = .35f;
	
	void Start(){
		StartCoroutine(ChangeSirenColor());
	}
	void Update () {
		if (!GameManager.Instance.GameOver){
			HandleUserInput();
		} else {
			GameOver();
		}
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
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
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
			FindObjectOfType<ObstacleController>().DestroyObstacle(obstacle);
			GameManager.Instance.SubtractHealth(damage);
		} else if (other.tag == "Train"){
			other.GetComponent<BoxCollider2D>().isTrigger = false;
			Train train = other.GetComponentInParent<Train>();
			int damage = train.Damage;
			GameManager.Instance.SubtractHealth(damage);
			GameManager.Instance.SetTipText("Tip: Running into a train instantly kills you.");
		} else if (other.tag == "Heart"){
			Obstacle obstacle = other.GetComponent<Obstacle>();
			if (GameManager.Instance.AddHealth()){
				FindObjectOfType<ObstacleController>().DestroyObstacle(obstacle);
			}
		} else if (other.tag == "GameOver"){
			GameManager.Instance.ShowGameOverPanel();
		} else if (other.tag == "Criminal"){
			Criminal criminal = other.GetComponent<Criminal>();
			criminal.GetComponent<PolygonCollider2D>().isTrigger = false;
		}
	}

	public void GameOver(){
		transform.position = Vector3.MoveTowards(transform.position, new Vector3(-50f, transform.position.y, transform.position.z), 3.85f * Time.deltaTime);
	}
}
