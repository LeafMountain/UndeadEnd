using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalWinState : IGlobalState {

	GlobalStateMachine stateMachine;

	public void EnterState(GlobalStateMachine stateMachine){
		this.stateMachine = stateMachine;
	}

	public void ExitState(){

	}

	public void Update () {
		
	}
}
