using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerCooldown : MonoBehaviour {

	public float cooldown;

	public UnityEvent OnTriggered;

	bool ready = true;

	public void Trigger(){
		TriggerTrigger();
	}

	IEnumerator Cooldown(float time){
		yield return new WaitForSeconds(time);
		ready = true;
	}

	void TriggerTrigger(){
		if(ready){
			OnTriggered.Invoke();
			ready = false;
			StartCoroutine("Cooldown", cooldown);
		}
	}
}
