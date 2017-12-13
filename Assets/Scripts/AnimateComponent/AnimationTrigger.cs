using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AnimationTrigger {

	public string name;
	public GameEvent gameEvent;

	Animator animator;

	public void Initialize(Animator animator){
		gameEvent.AddListener(Trigger);
		this.animator = animator;
	}

	void Trigger(){
		animator.SetTrigger(name);
	}
}
