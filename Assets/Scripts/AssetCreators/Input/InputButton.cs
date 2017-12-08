using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputButton : MonoBehaviour {

	public string buttonName;

	public UnityEvent OnButtonDown;
	public UnityEvent OnButtonStay;
	public UnityEvent OnButtonUp;

	void Update(){
		if(Input.GetButtonDown(buttonName)) { OnButtonDown.Invoke(); }
		if(Input.GetButton(buttonName)) { OnButtonStay.Invoke(); }
		if(Input.GetButtonUp(buttonName)) { OnButtonUp.Invoke(); }
		
	}
}
