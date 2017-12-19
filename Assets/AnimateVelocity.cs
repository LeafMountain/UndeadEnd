using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
public class AnimateVelocity : MonoBehaviour {

	Rigidbody rb;
	NavMeshAgent agent;
	Animator animator;

	void Start(){
		rb = GetComponent<Rigidbody>();
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
	}

	void Update(){
		if(rb){
			animator.SetFloat("Velocity", rb.velocity.magnitude);
		} else if (agent) {
			animator.SetFloat("Velocity", agent.velocity.magnitude);
		}
	}

}
