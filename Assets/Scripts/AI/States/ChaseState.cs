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
	}
	
	public void Update () {
		if(DistanceToDestination <= 0.1f){
			controller.ChangeState(new IdleState(controller));
		}
	}
}
