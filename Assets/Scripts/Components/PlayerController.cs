using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Mover), typeof(Rotator))]
public class PlayerController : MonoBehaviour {

	[SerializeField]
	InputProfile profile;

	public UnityEvent interactButton;
	public UnityEvent fireButton;

	Mover mover;
	Rotator rotator;
	Camera viewCamera;
	Flashlight flashlight;

	Vector3 lookDirection;

	void Start(){
		mover = GetComponent<Mover>();
		rotator = GetComponent<Rotator>();
		viewCamera = Camera.main;
		flashlight = GetComponent<Flashlight>();
	}

	void Update(){		
		Move();
		Look();
		ToggleFlashlight();
		// Shoot();

		if(Input.GetButtonDown(profile.shoot)){
			fireButton.Invoke();
		}

		if(Input.GetButtonDown(profile.interact)){
			interactButton.Invoke();
		}
	}

	void Move(){
		if(mover){
			Vector3 input = new Vector3(Input.GetAxisRaw(profile.horizontalMove),0, Input.GetAxisRaw(profile.verticalMove)).normalized;
			mover.Move(input);
		}
	}

	public float lookRotation;

	void Look(){
		if(rotator){
			Vector3 input = Vector3.zero;
			float lookAngle = 0;

			if(!profile.useMouse) {
				Vector3 stickInput = new Vector3(Input.GetAxisRaw(profile.horizontalLook), 0, Input.GetAxisRaw(profile.verticalLook)).normalized;
				// lookAngle = Vector3.Angle(Vector3.zero, stickInput);
				Quaternion test = Quaternion.LookRotation(stickInput, Vector3.up);
				lookAngle = test.eulerAngles.y;
			} else {
				Vector3 mousePosition = Vector3.zero;;
				Ray mouseRay = viewCamera.ScreenPointToRay(Input.mousePosition);
				Debug.DrawRay(mouseRay.origin, mouseRay.direction * 100, Color.red);
				RaycastHit hit;

				if(Physics.Raycast(mouseRay, out hit, Mathf.Infinity)){
					mousePosition = hit.point;
				}

				input = mousePosition;
			}

			input.y = 0;
			
			if(input != Vector3.zero) {
				// rotator.Rotate(input, profile.useMouse);
			}
			rotator.Rotate(lookAngle);
			
		}	
	}

	void ToggleFlashlight(){
		if(flashlight && Input.GetButtonDown(profile.toggleFlashlight)) {
			flashlight.ToggleLight();
		}
	}
}
