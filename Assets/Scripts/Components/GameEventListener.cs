﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour {

	public GameEvent Event;
	public UnityEvent onRaised;

	void OnEnable(){
		Event.AddListener(this);
	}

	void OnDisable(){
		Event.RemoveListener(this);
	}

	public void Raised(){
		onRaised.Invoke();
	}
}
