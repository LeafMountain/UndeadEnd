using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSlot : MonoBehaviour {

	public GameObject gameObject;

	public void SetGameObject(GameObject go){
		RemoveGameObject();
		gameObject = go;
	}

	public void RemoveGameObject(){
		if(gameObject != null){
			Destroy(gameObject);
		}
	}
}
