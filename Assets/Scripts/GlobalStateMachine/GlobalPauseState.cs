using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalPauseState : IGlobalState {

	GlobalStateMachine stateMachine;

	public void EnterState(GlobalStateMachine stateMachine){
		this.stateMachine = stateMachine;
		Time.timeScale = 0;
		Debug.Log("Pause");
	}

	public void ExitState(){
		Time.timeScale = 1;
	}

	public void Update () {
		
	}
}
