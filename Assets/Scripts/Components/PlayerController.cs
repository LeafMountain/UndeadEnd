using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover), typeof(Rotator))]
public class PlayerController : MonoBehaviour {

	[SerializeField]
	InputProfile profile;

	Mover mover;
	Rotator rotator;
	Camera viewCamera;
	Flashlight flashlight;
	Inventory inventory;

	Vector3 lookDirection;

	void Start(){
		mover = GetComponent<Mover>();
		rotator = GetComponent<Rotator>();
		viewCamera = Camera.main;
		flashlight = GetComponent<Flashlight>();
		inventory = GetComponent<Inventory>();
	}

	void Update(){		
		Move();
		Look();
		ToggleFlashlight();
		Shoot();
	}

	void Move(){
		if(mover){
			Vector3 input = new Vector3(Input.GetAxisRaw(profile.horizontalMove),0, Input.GetAxisRaw(profile.verticalMove)).normalized;
			
			mover.Move(input);
		}
	}

	void Look(){
		if(rotator){
		Vector3 input = Vector3.zero;

			if(!profile.useMouse) {
				input += new Vector3(Input.GetAxisRaw(profile.horizontalLook), 0, Input.GetAxisRaw(profile.verticalLook)).normalized;
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
				rotator.Rotate(input, profile.useMouse);
			}
		}	
	}

	void ToggleFlashlight(){
		if(flashlight && Input.GetButtonDown(profile.toggleFlashlight)) {
			flashlight.ToggleLight();
		}
	}

	void Shoot(){
		if(inventory && Input.GetButtonDown(profile.shoot)){
			if(inventory.weapon){
				inventory.weapon.Use();
			}
		}
	}
}
