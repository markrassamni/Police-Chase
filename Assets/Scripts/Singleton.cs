using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T> {

	private static T instance;
	public static T Instance { get { return instance; } }

	protected void Awake(){
		if (instance != null && instance != this){
            Destroy(this.gameObject);
        } else {
            instance = this as T;
        }
	}
}