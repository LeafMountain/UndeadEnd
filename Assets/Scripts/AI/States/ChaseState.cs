using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IAIState {

	AIController controller;
	Vector3 destination;

	float DistanceToDestination {
		get{
			return controller.agent.remainingDistance;
		}
	}

	public ChaseState(AIController controller, Vector3 targetPosition){
		this.controller = controller;
		controller.agent.SetDestination(targetPosition);
		Debug.Log(targetPosition);
	}
	
	public void Update () {
		if(DistanceToDestination < controller.agent.stoppingDistance){
			controller.ChangeState(new IdleState(controller));
		}
	}
}
