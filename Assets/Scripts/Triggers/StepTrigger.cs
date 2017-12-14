using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StepTrigger : MonoBehaviour {
	
	public bool PlayOnEnable;

	[SerializeField]
	List<Step> triggers = new List<Step>();

	bool currentlyRunning;
	int currentIndex;

	public void OnEnable(){
		if(PlayOnEnable){
			StartSequence();
		}
	}

	public void StartSequence(){
		if(triggers != null && triggers.Count > 0 && !currentlyRunning){
			currentIndex = 0;
			StartCoroutine("DoStep", triggers[currentIndex].time);
		}
	}

	IEnumerator DoStep(float time){
		yield return new WaitForSeconds(time);
		triggers[currentIndex].Do();
		
		currentIndex = (triggers[currentIndex].loop) ? triggers[currentIndex].goToStep : currentIndex + 1;
		

		if(currentIndex < triggers.Count){
			//Do next step			
			Step nextStep = triggers[currentIndex];
			
			Debug.Log(currentIndex);
			
			StartCoroutine("DoStep", nextStep.time);
		} else {
			currentIndex = 0;
			currentlyRunning = false;
			Debug.Log("Sequence done");			
		}
		
	}
}

[System.Serializable]
class Step {
	public float time;
	public UnityEvent OnAction;

	public bool loop;
	public int goToStep;

	public void Do(){
		OnAction.Invoke();
	}
}
