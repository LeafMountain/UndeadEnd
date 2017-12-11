using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	public enum RelativeDirection { World, Camera, Self }
	public RelativeDirection relativeTo;
	public bool add;

	public void Rotate(Vector2 input){
		Vector3 _input = new Vector3(input.x, 0, input.y);
		Vector3 lookDirection = Vector3.zero;

		switch (relativeTo) {
			case(RelativeDirection.World):
				lookDirection = _input;
				break;
			case(RelativeDirection.Camera):
				lookDirection = ConvertToCameraForward(_input);
				break;
			case(RelativeDirection.Self):
				lookDirection = ConvertToSelfForward(_input);
				break;
		}

		lookDirection += transform.position;
		transform.LookAt(lookDirection);
	}

	public void SetRotation(float pitch, float yaw, float roll){
		SetRotation(Quaternion.Euler(pitch, yaw, roll));
	}

	public void SetRotation(Quaternion rotation){
		Quaternion newRotation = (add) ? Quaternion.Euler(transform.rotation.eulerAngles + rotation.eulerAngles) : rotation;
		transform.rotation = newRotation;
	}

	Vector3 ConvertToCameraForward(Vector3 position){
		Transform cameraTransform = Camera.main.transform;
		
		Vector3 cameraForward = cameraTransform.forward;
		cameraForward.y = 0;
		Vector3 cameraRight = cameraTransform.right;
		cameraRight.y = 0;
		Vector3 cameraUp = cameraTransform.up;
		cameraUp.y = 0;

		return (cameraForward + cameraUp) * position.z + cameraRight * position.x;
	}

	Vector3 ConvertToSelfForward(Vector3 position){
		return transform.forward * position.z + transform.right * position.x;
	}
}
