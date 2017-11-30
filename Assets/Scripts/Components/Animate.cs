using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Animate : MonoBehaviour {

	public AnimationFloat[] floats;
	public AnimationInt[] ints;	
	public AnimationBool[] bools;
	public AnimationTrigger[] triggers;

	Animator animator;

	void Start(){
		animator = GetComponent<Animator>();

		ListenToEvents();
	}

	void Update(){
		UpdateFloats();
		UpdateInts();
		UpdateBools();
	}

	void UpdateFloats(){
		if(floats != null){
			for (int i = 0; i < floats.Length; i++){
				animator.SetFloat(floats[i].name, floats[i].value.Value);
			}
		}
	}

	void UpdateInts(){
		if(ints != null){
			for (int i = 0; i < ints.Length; i++){
				animator.SetFloat(ints[i].name, ints[i].value.Value);
			}
		}
	}

	void UpdateBools(){
		if(bools != null){
			for (int i = 0; i < bools.Length; i++){
				animator.SetBool(bools[i].name, bools[i].value.Value);
			}
		}
	}

	void ListenToEvents(){
		for (int i = 0; i < triggers.Length; i++)
		{
			triggers[i].Initialize(animator);
		}
	}
}
