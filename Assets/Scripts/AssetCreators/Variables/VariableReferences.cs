using System;
using UnityEngine;

[Serializable]
public class VariableReference<Type, VariableType> where VariableType : InspectorVariable<Type> {

	public bool useConstant = false;
	public Type constantValue;
	public VariableType variable;

	public Type Value{
		get {
			return useConstant ? constantValue : variable.Value;
		}
	}
}

[Serializable]
public class FloatReference : VariableReference<float, FloatVariable> { }

[Serializable]
public class IntReference : VariableReference<int, IntVariable> { }

[Serializable]
public class BoolReference : VariableReference<bool, BoolVariable> { }

[Serializable]
public class StringReference : VariableReference<string, StringVariable> { }

[Serializable]
public class ColorReference : VariableReference<Color, ColorVariable> { }
