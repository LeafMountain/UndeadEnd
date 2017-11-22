using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class TriggerOverlap : MonoBehaviour {

	public Collider[] exclusiveTo;

	public UnityGameObjectEvent OnTriggerEntered;
	public UnityGameObjectEvent OnTriggerExited;
	
	void OnTriggerEnter(Collider col){
		GameObject go = col.gameObject;

		if(exclusiveTo != null && exclusiveTo.Length > 0){
			for (int i = 0; i < exclusiveTo.Length; i++){
				if(exclusiveTo[i] == col){
					OnTriggerEntered.Invoke(go);
				}
			}
		} else {
			OnTriggerEntered.Invoke(go);
		}
	}

	void OnTriggerExit(Collider col){
		GameObject go = col.gameObject;
		
		if(exclusiveTo != null){
			for (int i = 0; i < exclusiveTo.Length; i++){
				if(exclusiveTo[i] == col){
					OnTriggerExited.Invoke(go);
				}
			}

		} else {
			OnTriggerExited.Invoke(go);
		}
	}

}
