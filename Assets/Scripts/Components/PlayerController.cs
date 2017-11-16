using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mover), typeof(Rotator))]
public class PlayerController : MonoBehaviour {

	public bool useMouse;

	//variable to pick controller (which player)
	public string horizontalInput = "LookHorizontal";
	public string verticalInput = "LookVertical";

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
	}

	void Move(){
		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
		mover.Move(input);
	}

	void Look(){
		Vector3 input = Vector3.zero;

		if(!useMouse){
			input += new Vector3(Input.GetAxisRaw(horizontalInput), 0, Input.GetAxisRaw(verticalInput)).normalized;
		} else{
			Vector3 mousePosition = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
			input += (mousePosition + Vector3.up * rotator.transform.position.y).normalized;
			input.y = 0;
		}
		
		if(input != Vector3.zero) {
			rotator.Rotate(input, false);
		}
	}

	void ToggleFlashlight(){
		if(Input.GetButtonDown("LeftBumper")) {
			flashlight.ToggleLight();
		}
	}
}
