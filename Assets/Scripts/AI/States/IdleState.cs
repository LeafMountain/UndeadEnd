using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IAIState {

	AIController controller;
	float timeToRest;

	float DistanceToDestination {
		get{
			return controller.agent.remainingDistance;
		}
	}

	public IdleState(AIController controller){
		this.controller = controller;	
		timeToRest = Random.Range(0f, 3f);
	}
	
	public void Update () {
		timeToRest -= Time.deltaTime;

		if(timeToRest <= 0){
			controller.ChangeState(new WanderState(controller));
		}
	}
}
