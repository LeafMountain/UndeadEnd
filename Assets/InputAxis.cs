using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAxis : MonoBehaviour {


	public string horizontalName;
	public string verticalName;

	public UnityVector2Event OnInput;

	void Update(){
		float h = (horizontalName != null && horizontalName != "") ? Input.GetAxisRaw(horizontalName) : 0;
		float v = (verticalName != null && verticalName != "") ? Input.GetAxisRaw(verticalName) : 0;
		
		OnInput.Invoke(new Vector2(h, v).normalized);
	}	
}
