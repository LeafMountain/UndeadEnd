using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class CharacterController : MonoBehaviour {

	public enum MoveDirection { Camera, World, Self }

	//Settings
	public MoveDirection moveRelativeTo;
	[Range(0.01f, 1f)]
	public float speed = .1f;
	public float stepSize;	//Fix

	//Velocity
	Vector3 lastPosition;
	public Vector3 Velocity { get; private set; }
	public float VelocityMagnitude { get { return Velocity.magnitude; } }
	public float VelocityMagnitudePercentage { get; private set; }

	//Grounded
	public bool IsGrounded { get; set; }		//Fix

	Rigidbody rigidbody;
	Vector3 moveDirection;	

	void Start(){
		rigidbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate(){
		rigidbody.MovePosition(transform.position + (moveDirection * speed));
	}

	void Update(){
		lastPosition = transform.position;
		Velocity = (lastPosition - transform.position);
	}

	//Move
	public void Move(Vector2 input){
		Move(input, false);
	}

	public void Move(Vector2 input, bool YtoZ){
		Vector3 inputToVector3 = (YtoZ) ? new Vector3(input.x, 0, input.y) : new Vector3(input.x, input.y, 0);
		Move(inputToVector3);
	}

	public void Move(Vector3 input){
		Vector3 moveDirection = Vector3.zero;

		switch (moveRelativeTo) {
			case(MoveDirection.Camera):
				moveDirection = ConvertToCameraForward(input);
				break;
			case(MoveDirection.World):
				moveDirection = input;
				break;
			case(MoveDirection.Self):
				moveDirection = ConvertToSelfForward(input);
				break;
			default:
				break;
		}

		this.moveDirection = moveDirection;
	}

	//Convert
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
