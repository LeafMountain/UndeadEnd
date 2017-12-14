using UnityEngine;

[System.Serializable]
public class InspectorVariable<T> : ScriptableObject {
#if UNITY_EDITOR
	[Multiline]
	public string DeveloperDescription = "";
#endif

	public T Value;

	public void SetValue(T value){
		Value = value;
	}
}

[CreateAssetMenu(menuName="Variables/Float")]
public class FloatVariable : InspectorVariable<float> {
	public void ApplyChange(float amount){
		Value += amount;
	}
}

[CreateAssetMenu(menuName="Variables/Int")]
public class IntVariable : InspectorVariable<int> { 
	public void ApplyChange(int amount){
		Value += amount;
	}
}

[CreateAssetMenu(menuName="Variables/Bool")]
public class BoolVariable : InspectorVariable<bool> { }

[CreateAssetMenu(menuName="Variables/String")]
public class StringVariable : InspectorVariable<string> { }

[CreateAssetMenu(menuName="Variables/Color")]
public class ColorVariable : InspectorVariable<Color> { }