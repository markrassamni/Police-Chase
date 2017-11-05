using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	[SerializeField] private float moveSpeed = 3.85f;
	[SerializeField] private Transform[] spawnPoints;
	[SerializeField][Range(0, 3)] private int damage;

	public int Damage { get{ return damage; } }

	public float MoveSpeed{
		get{
			return moveSpeed;
		}
	}

	public Transform[] SpawnPoints{
		get{
			return spawnPoints;
		}
	}

	virtual public void Move(){
		transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
	}
}
