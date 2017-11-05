using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Obstacle {

	[SerializeField] private float changeSpriteSpeed;
	[SerializeField] private Sprite[] sprites;
	private SpriteRenderer spriteRenderer;
	private int currentSprite = 1;

	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
		StartCoroutine(Animate());
	}
	
	private IEnumerator Animate(){
		yield return new WaitForSeconds(changeSpriteSpeed);
		if (currentSprite < sprites.Length){
			currentSprite += 1;
		} else {
			currentSprite = 1;
		}
		spriteRenderer.sprite = sprites[currentSprite-1];
		if (!GameManager.Instance.GameOver){
			StartCoroutine(Animate());
		}
	}
}
