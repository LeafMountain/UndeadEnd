using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XInputDotNetPure;

[RequireComponent(typeof(Mover), typeof(Rotator))]
public class PlayerController : MonoBehaviour {

	public bool keyboard;

	[SerializeField]
	public PlayerIndex playerIndex;

	public UnityEvent OnStart;

	public UnityVector2Event moveInput;
	public UnityVector2Event lookInput;

	public UnityEvent interactButton;
	public UnityEvent fireButton;

	GamePadState pad;

	void Update(){
		pad = GamePad.GetState(playerIndex);

		if(!keyboard){
			Move(new Vector2(pad.ThumbSticks.Left.X, pad.ThumbSticks.Left.Y));
			Fire(pad.Triggers.Right > .1f);			
			Look(new Vector2(pad.ThumbSticks.Right.X, pad.ThumbSticks.Right.Y));
		} else {
			Move((new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized));
			Fire(Input.GetButton("Fire1"));

			Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			Physics.Raycast(mouseRay, out hit, Mathf.Infinity);
			Debug.DrawRay(mouseRay.origin, mouseRay.direction * 100, Color.red);
			Vector2 lookDir = new Vector2(hit.point.x - transform.position.x, hit.point.z - transform.position.z).normalized;
			Look(lookDir);
		}

		ToggleFlashlight();
		PauseButton();
	}

	void Move(Vector2 input){
		if(moveInput != null){
			moveInput.Invoke(input);
		}
	}

	void Look(Vector2 input){
		if(lookInput != null){
			lookInput.Invoke(input);
		}
	}

	void ToggleFlashlight(){
		if(interactButton != null){
			interactButton.Invoke();
		}
	}

	void Fire(bool input){
		if(fireButton != null && input){
			fireButton.Invoke();
		}
	}

	void PauseButton(){
		if(OnStart != null && Input.GetButton("Cancel")) {
			OnStart.Invoke();
		}
	}
}
