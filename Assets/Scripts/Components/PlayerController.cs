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

		if(!useMouse) {
			input += new Vector3(Input.GetAxisRaw(horizontalInput), 0, Input.GetAxisRaw(verticalInput)).normalized;
		} else {
			// Vector3 mousePosition = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
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
			rotator.Rotate(input, useMouse);
		}
	}

	void ToggleFlashlight(){
		if(Input.GetButtonDown("LeftBumper")) {
			flashlight.ToggleLight();
		}
	}
}
