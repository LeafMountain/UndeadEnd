﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatVariable : ScriptableObject {

#if UNITY_EDITOR
	[Multiline]
	public string DeveloperDescription = "";
#endif

	public float Value;

	public void SetValue(float value){
		Value = value;
	}

	public void SetValue(FloatReference value){
		Value = value.Value;
	}

	public void ApplyChange(float amount){
		Value += amount;
	}

	public void ApplyChange(FloatReference amount){
		Value += amount.Value;
	}
}