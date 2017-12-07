using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalStartState : IGlobalState {

	GlobalStateMachine stateMachine;

	public void EnterState(GlobalStateMachine stateMachine){
		this.stateMachine = stateMachine;
		Debug.Log("Start state");
		SceneManager.LoadScene(stateMachine.GameScene.name);
		stateMachine.EnterPlay();
	}

	public void ExitState(){

	}

	public void Update () {
		
	}
}
