using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour {

	public GameObject instantiatedObject;
	public Transform position;
	public Transform rotation;
	public float amount = 1;

	void Start(){
		if(!position){
			position = transform;
		}

		if(!rotation){
			rotation = transform;
		}
	}

	public void Instantiate(){
		for (int i = 0; i < amount; i++) {
			GameObject.Instantiate(instantiatedObject, position.position, rotation.rotation);
		}
	}
}
