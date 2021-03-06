﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

	[SerializeField] private float moveSpeed;
	[SerializeField] private Sprite blueSiren;
	[SerializeField] private Sprite redSiren;
	private const float minY = -4.2f;
	private const float maxY = 4.2f;
	private  float minX = -7f;
	private  float maxX = 7f;
	private const float sirenTime = .35f;
	
	void Start(){
		StartCoroutine(ChangeSirenColor());
		SoundController.Instance.SetSfxSource(GetComponent<AudioSource>());
		float verticalBound = Camera.main.GetComponent<Camera>().orthographicSize; 
        float horizontalBound = verticalBound * Screen.width / Screen.height;
		float carLength = GetComponent<BoxCollider2D>().size.x;
		minX = -horizontalBound + carLength + .35f;
		maxX = horizontalBound - carLength;
		transform.position = new Vector3(minX, 0f, transform.position.z);
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
		if (!GameManager.Instance.GameOver && ! GameManager.Instance.GameWon){
			if (other.tag == "Obstacle"){
				Obstacle obstacle = other.GetComponentInParent<Obstacle>();
				if(obstacle.GetComponent<Dog>() != null){
					SoundController.Instance.PlayDogBark();
				} else {
					SoundController.Instance.PlayDamage();
				}
				int damage = obstacle.Damage;
				GameManager.Instance.SubtractHealth(damage);
				FindObjectOfType<ObstacleController>().DestroyObstacle(obstacle);
			} else if (other.tag == "Train"){
				SoundController.Instance.PlayTrainHorn();
				other.GetComponent<Collider2D>().isTrigger = false;
				Train train = other.GetComponentInParent<Train>();
				int damage = train.Damage;
				GameManager.Instance.SubtractHealth(damage);
				GameManager.Instance.SetTipText("Tip: Running into a train instantly kills you.");
			} else if (other.tag == "GameOver"){
				GameManager.Instance.ShowGameLostPanel();
			} else if (other.tag == "Criminal"){
				Criminal criminal = other.GetComponent<Criminal>();
				criminal.GetComponent<Collider2D>().isTrigger = false;
				StartCoroutine(GameManager.Instance.WinGame());
				criminal.SetMoveSpeedToRoadSpeed();
				GetComponent<Rigidbody2D>().isKinematic = true;
			}
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (!GameManager.Instance.GameOver && ! GameManager.Instance.GameWon){
			if (other.tag == "Heart"){
				Obstacle obstacle = other.GetComponent<Obstacle>();
				if (GameManager.Instance.AddHealth()){
					FindObjectOfType<ObstacleController>().DestroyObstacle(obstacle);
					SoundController.Instance.PlayHeal();
				}
			}
		}
	}

	public void GameOver(){
		transform.position = Vector3.MoveTowards(transform.position, new Vector3(-50f, transform.position.y, transform.position.z), 3.85f * Time.deltaTime);
	}
}
