using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InputAxis {
	public string prefix;
	public string horizontalName;
	public string verticalName;

	public UnityVector2Event OnInput;

	public void Update(string suffix = ""){
		float h = (horizontalName != null && horizontalName != "") ? Input.GetAxisRaw(prefix + horizontalName + suffix) : 0;
		float v = (verticalName != null && verticalName != "") ? Input.GetAxisRaw(prefix + verticalName + suffix) : 0;
		
		OnInput.Invoke(new Vector2(h, v).normalized);
	}	
}
