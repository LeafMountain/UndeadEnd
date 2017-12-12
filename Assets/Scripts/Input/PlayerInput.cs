using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour {

	public InputProfile inputProfile;

	public UnityVector2Event OnMoveInput;
	public UnityVector2Event OnLookInput;

	public UnityEvent OnUseInput;

	void Update(){
		Move();
		Shoot();
	}

	void Shoot(){
		if(Input.GetButtonDown(inputProfile.Shoot)){
			OnUseInput.Invoke();
		}
	}

	void Move(){
		Vector2 input = new Vector2(Input.GetAxisRaw(inputProfile.HorizontalMove), Input.GetAxisRaw(inputProfile.VerticalMove)).normalized;

		OnMoveInput.Invoke(input);
	}
	
	void Look(){
		Vector2 input = new Vector2(Input.GetAxisRaw(inputProfile.HorizontalLook), Input.GetAxisRaw(inputProfile.VerticalLook)).normalized;

		OnLookInput.Invoke(input);
	}
}
