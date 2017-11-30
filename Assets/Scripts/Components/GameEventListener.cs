using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour {

	public GameEvent Event;
	public UnityEvent onRaised;

	void OnEnable(){
		Event.AddListener(Raised);
	}

	void OnDisable(){
		Event.RemoveListener(Raised);
	}

	public void Raised(){
		onRaised.Invoke();
	}
}
