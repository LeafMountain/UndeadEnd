using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalMenuState : IGlobalState {

	GlobalStateMachine stateMachine;

	public void EnterState(GlobalStateMachine stateMachine){
		this.stateMachine = stateMachine;
		SceneManager.LoadScene(stateMachine.MenuScene.name);
	}

	public void ExitState(){

	}

	public void Update () {
		
	}
}
