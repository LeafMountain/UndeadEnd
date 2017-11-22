using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour {

	public AnimationFloat[] animationFloats;

	Animator animator;

	Mover mover;

	void Start(){
		animator = GetComponent<Animator>();
		mover = GetComponent<Mover>();
	}

	void Update () {
		// animator.SetFloat("velocity", mover.Velocity);
		// Debug.Log(mover.currentSpeedPercentage);

		if(animationFloats != null){
			for (int i = 0; i < animationFloats.Length; i++) {
				animationFloats[i].SetFloat(animator);
			}
		}
	}
}
