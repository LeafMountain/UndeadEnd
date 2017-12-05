using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIController : MonoBehaviour {

	IAIState currentState;
	public NavMeshAgent agent;

	public void ChangeState(IAIState newState){
		currentState = newState;
	}

	void Start(){
		agent = GetComponent<NavMeshAgent>();
		currentState = new WanderState(this);
	}

	void Update(){
		currentState.Update();
	}
}
