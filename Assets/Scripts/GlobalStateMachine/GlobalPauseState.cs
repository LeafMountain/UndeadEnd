using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalPauseState : IGlobalState {

	GlobalStateMachine stateMachine;

	public void EnterState(GlobalStateMachine stateMachine){
		this.stateMachine = stateMachine;
		Time.timeScale = 0;
	}

	public void ExitState(){

	}

	public void Update () {
		
	}
}
