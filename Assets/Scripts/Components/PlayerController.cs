using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XInputDotNetPure;

[RequireComponent(typeof(Mover), typeof(Rotator))]
public class PlayerController : MonoBehaviour {

	[SerializeField]
	public PlayerIndex playerIndex;

	public UnityVector2Event moveInput;
	public UnityVector2Event lookInput;

	public UnityEvent interactButton;
	public UnityEvent fireButton;

	GamePadState pad;

	Vector3 lookDirection;

	void Update(){
		pad = GamePad.GetState(playerIndex);

		Move();
		Look();
		ToggleFlashlight();
		Fire();
	}

	void Move(){
		if(moveInput != null){
			Vector2 input = new Vector2(pad.ThumbSticks.Left.X, pad.ThumbSticks.Left.Y);			
			moveInput.Invoke(input);
		}
	}

	void Look(){
		if(lookInput != null){
			Vector2 input = new Vector2(pad.ThumbSticks.Right.X, pad.ThumbSticks.Right.Y);
			lookInput.Invoke(input);
		}
	}

	void ToggleFlashlight(){
		if(interactButton != null){
			interactButton.Invoke();
		}
	}

	void Fire(){
		if(fireButton != null && pad.Triggers.Right > .1f){
			fireButton.Invoke();
		}
	}
}
