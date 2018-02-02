using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateMachineController : MonoBehaviour {

	public List<StateMachineState> states;

	StateMachineState currentState;

	void Start(){
		if(states != null && states.Count > 0){
			ChangeState(0);
		}
	}

	public void ChangeState(StateMachineState newState){
		if(currentState != null){
			currentState.Exit();
		}
		currentState = newState;
		currentState.Enter();
	}

	public void ChangeState(int index){
		if(states.Count >= index){
			ChangeState(states[index]);
		} else {
			Debug.LogError("Index out of range.");
		}

	}

	public void ChangeState(string name){
		StateMachineState state;
		
		for (int i = 0; i < states.Count; i++)
		{
			if(states[i].name == name){
				state = states[i];
				ChangeState(state);
				return;
			}
		}

		Debug.LogError("No state called " + name);
	}
}

[System.Serializable]
public class StateMachineState {
	public string name;
	public UnityEvent OnStateEnter;
	public UnityEvent OnStateExit;

	public void Enter(){
		OnStateEnter.Invoke();
	}

	public void Exit(){
		OnStateExit.Invoke();
	}
}
