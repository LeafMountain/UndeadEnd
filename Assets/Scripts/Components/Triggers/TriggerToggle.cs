using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerToggle : MonoBehaviour {

	public UnityEvent ToggleOn;
	public UnityEvent ToggleOff;

	bool toggle;

	public void Toggle(){
		toggle = !toggle;

		if(toggle){
			ToggleOn.Invoke();
		} else {
			ToggleOff.Invoke();
		}
	}
}
