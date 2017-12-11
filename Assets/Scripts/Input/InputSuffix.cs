using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSuffix : MonoBehaviour {

	public StringReference playerSuffix;

	public void SetSuffix(GameObject go){
		InputMapper input = go.GetComponent<InputMapper>();

		if(input){
			input.SetSuffix(playerSuffix);
		}
	}
}
