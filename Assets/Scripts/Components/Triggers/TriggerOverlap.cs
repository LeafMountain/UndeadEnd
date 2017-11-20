using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class TriggerOverlap : MonoBehaviour {

	public UnityTriggerOverlapEvent OnTriggerEntered;
	public UnityTriggerOverlapEvent OnTriggerExited;
	
	void OnTriggerEnter(Collider col){
		OnTriggerEntered.Invoke(col);
	}

	void OnTriggerExit(Collider col){
		OnTriggerExited.Invoke(col);
	}

}

[System.Serializable]
public class UnityTriggerOverlapEvent : UnityEvent<Collider> { }
