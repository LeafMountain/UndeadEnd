using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour {

	public GameObject instantiatedObject;
	public Transform origin;

	void Start(){
		if(!origin){
			origin = transform;
		}
	}

	public void Instantiate(){
		GameObject.Instantiate(instantiatedObject, origin.position, origin.rotation);
	}
}
