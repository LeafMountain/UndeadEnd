using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InputButton {

	public string buttonName;

	public UnityEvent OnButtonDown;
	public UnityEvent OnButtonStay;
	public UnityEvent OnButtonUp;

	public void Update(string suffix = ""){
		if(Input.GetButtonDown(buttonName + suffix)) { OnButtonDown.Invoke(); }
		if(Input.GetButton(buttonName + suffix)) { OnButtonStay.Invoke(); }
		if(Input.GetButtonUp(buttonName + suffix)) { OnButtonUp.Invoke(); }
	}
}
