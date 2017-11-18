using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour {

	Animator animator;

	Mover mover;

	void Start(){
		animator = GetComponent<Animator>();
		mover = GetComponent<Mover>();
	}

	void Update () {
		animator.SetFloat("velocity", mover.Velocity);
		// Debug.Log(mover.currentSpeedPercentage);
	}
}
