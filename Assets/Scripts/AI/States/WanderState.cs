using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : IAIState {

	AIController controller;
	Vector3 destination;

	float DistanceToDestination {
		get{
			return controller.agent.remainingDistance;
		}
	}

	public WanderState(AIController controller){
		this.controller = controller;
		destination = FindPosition();
		controller.agent.SetDestination(destination);
	}
	
	public void Update () {
		if(DistanceToDestination < 3){
			controller.ChangeState(new IdleState(controller));
		}
	}

	Vector3 FindPosition(){
		float randomX = Random.Range(-1f, 1f);
		float randomZ = Random.Range(-1f, 1f);
		float randomDistance = Random.Range(controller.wanderLenghtMinMax.x, controller.wanderLenghtMinMax.y);

		Vector3 randomDirection = new Vector3(randomX, 0, randomZ);

		return controller.transform.position + (randomDirection * randomDistance);
	}
}
