using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSlot : MonoBehaviour {

	public GameObject go;

	public void SetGameObject(GameObject go){
		RemoveGameObject();
		this.go = go;
	}

	public void RemoveGameObject(){
		if(go != null){
			Destroy(go);
		}
	}
}
