using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalPlayState : IGlobalState {

	GlobalStateMachine stateMachine;

	public void EnterState(GlobalStateMachine stateMachine){
		this.stateMachine = stateMachine;
		Time.timeScale = 1;
	}

	public void ExitState(){

	}

	public void Update () {
		
	}
}
