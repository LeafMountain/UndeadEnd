using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Mover : MonoBehaviour {

	public enum MoveDirection { World, Camera, Self }

	public MoveDirection moveRelativeTo;

	[Range(0.01f, .3f)]
	public float normalSpeed = .1f;

	float currentSpeed;
	float targetSpeed;
	float speedSmoothVelocity;
	float speedSmoothTime = .1f;

	CharacterController controller;

	Vector3 velocity;
	public float Velocity { get{ return controller.velocity.magnitude; } }

	[HideInInspector]
	public float currentSpeedPercentage;

	Vector3 lastPosition;

	void Start(){
		controller = GetComponent<CharacterController>();
	}

	void Update(){
		velocity = (lastPosition - transform.position);
		lastPosition = transform.position;

		currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);
		currentSpeedPercentage = currentSpeed / normalSpeed;

		targetSpeed = 0;
	}

	public void Move(Vector3 input){
		Vector3 moveDirection = Vector3.zero;

		switch (moveRelativeTo) {
			case(MoveDirection.World):
				moveDirection = input;
				break;
			case(MoveDirection.Camera):
				Vector3 cameraForward = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized;
				Vector3 cameraRight = new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z).normalized;
				moveDirection = cameraForward * input.z + cameraRight * input.x;
				break;
			case(MoveDirection.Self):
				moveDirection = transform.forward * input.z + transform.right * input.x;
				break;
			default:
				break;
		}
		
		controller.Move(moveDirection * normalSpeed);
	}
}
