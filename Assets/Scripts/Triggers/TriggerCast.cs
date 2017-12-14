using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerCast : MonoBehaviour {

	public float length = 1;
	public Transform origin;

	void Start(){
		if(!origin){
			origin = transform;
		}
	}

	void Update(){

	}

	// void Cast(){
	// 	Ray ray = new Ray(origin.position, origin.forward);
	// 	RaycastHit hit;

	// 	if(Physics.Raycast(ray, out hit, length)){
	// 		Raise(hit.transform.gameObject);
	// 	}
	// }
	
}
