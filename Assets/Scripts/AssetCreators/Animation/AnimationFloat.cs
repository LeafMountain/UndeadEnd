using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AnimationVariable/Float")]
public class AnimationFloat : ScriptableObject {

	public string Name;
	public FloatReference Value;

	public void SetFloat(Animator animator){
		animator.SetFloat(Name, Value.Value);
	}
}
