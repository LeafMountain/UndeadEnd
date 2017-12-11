using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour {

	public GameObject instantiatedObject;
	public Transform origin;
	public UnityGameObjectEvent OnInstantiated;

	void Awake(){
		if(!origin){
			origin = transform;
		}
	}

	public void Instantiate(){
		Instantiate(instantiatedObject);
	}

	public void Instantiate(GameObject go){
		GameObject newGo = GameObject.Instantiate(go, origin.position, origin.rotation);
		OnInstantiated.Invoke(newGo);
	}
}
