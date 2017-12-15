using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
public class AnimateVelocity : MonoBehaviour {

	Rigidbody rigidbody;
	NavMeshAgent agent;
	Animator animator;

	void Start(){
		rigidbody = GetComponent<Rigidbody>();
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
	}

	void Update(){
		if(rigidbody){
			animator.SetFloat("Velocity", rigidbody.velocity.magnitude);
		} else if (agent) {
			animator.SetFloat("Velocity", agent.velocity.magnitude);
		}
	}

}
