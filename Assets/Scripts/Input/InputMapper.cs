using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMapper : MonoBehaviour {
	public StringReference suffix;
	public InputAxis[] axes;
	public InputButton[] buttons;

	void Start(){
		if(suffix == null){
			suffix = new StringReference();
			SetSuffix("");
		}
	}

	void Update(){
		for (int i = 0; i < axes.Length; i++){
			axes[i].Update(suffix.Value);
		}

		for (int i = 0; i < buttons.Length; i++){
			buttons[i].Update(suffix.Value);
		}
	}

	public void SetSuffix(string suffix){
		this.suffix.useConstant = true;
		this.suffix.constantValue = suffix;
	}

	public void SetSuffix(StringReference suffix){
		this.suffix.useConstant = false;		
		this.suffix = suffix;
	}
}
