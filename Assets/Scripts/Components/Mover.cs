using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour {

	public enum MoveDirection { Camera, World, Self }

	public MoveDirection moveRelativeTo;

	[Range(0.01f, 1f)]
	public float normalSpeed = .1f;

	// CharacterController controller;
	Rigidbody rb;

	Vector3 velocity;
	public float Velocity { get{ return rb.velocity.magnitude; } }

	[HideInInspector]
	public float currentSpeedPercentage;	//Make this into a property

	// Vector3 lastPosition;
	Vector3 moveDirection;

	[SerializeField]
	public UnityFloatEvent OnVelocity;

	void Start(){
		rb = GetComponent<Rigidbody>();
	}

	void Update(){
		OnVelocity.Invoke(Velocity);
	}

	void FixedUpdate(){
		rb.MovePosition(transform.position + (moveDirection * normalSpeed));
	}

	public void Move(Vector2 input){
		Vector3 _input = new Vector3(input.x, 0, input.y);
		Vector3 moveDirection = Vector3.zero;

		switch (moveRelativeTo) {
			case(MoveDirection.Camera):
				moveDirection = ConvertToCameraForward(_input);
				break;
			case(MoveDirection.World):
				moveDirection = _input;
				break;
			case(MoveDirection.Self):
				moveDirection = ConvertToSelfForward(_input);
				break;
			default:
				break;
		}

		this.moveDirection = moveDirection;
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
