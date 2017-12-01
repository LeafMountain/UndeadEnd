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

	public void Move(Vector2 input){
		Vector3 _input = new Vector3(input.x, 0, input.y);
		Vector3 moveDirection = Vector3.zero;

		switch (moveRelativeTo) {
			case(MoveDirection.World):
				moveDirection = _input;
				break;
			case(MoveDirection.Camera):
				moveDirection = ConvertToCameraForward(_input);
				break;
			case(MoveDirection.Self):
				moveDirection = ConvertToSelfForward(_input);
				break;
			default:
				break;
		}

		controller.Move(moveDirection * normalSpeed);
	}

	Vector3 ConvertToCameraForward(Vector3 position){
		Transform cameraTransform = Camera.main.transform;
		
		Vector3 cameraForward = cameraTransform.forward;
		cameraForward.y = 0;
		Vector3 cameraRight = cameraTransform.right;
		cameraRight.y = 0;
		Vector3 cameraUp = cameraTransform.up;
		cameraUp.y = 0;

		return ((cameraForward + cameraUp) * position.z + cameraRight * position.x).normalized;
	}

	Vector3 ConvertToSelfForward(Vector3 position){
		return transform.forward * position.z + transform.right * position.x;
	}
}
