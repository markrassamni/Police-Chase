using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private GameManager instance;
	public GameManager Instance { get { return instance; } }

	void Start () {
		if (instance != null && instance != this){
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
	}
	
	void Update () {
		
	}
}
