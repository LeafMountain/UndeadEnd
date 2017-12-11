using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerOnEnable : MonoBehaviour {

	public UnityEvent Enable;

	void OnEnable(){
		Enable.Invoke();
	}
}
