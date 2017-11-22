using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	Camera viewCamera;

	void Start(){
		viewCamera = Camera.main;
	}

	public void Rotate(Vector3 input, bool globalDirection){
		Vector3 lookDirection = Vector3.zero;

		if(globalDirection){
			lookDirection = input;
		} else {
			Vector3 cameraForward = viewCamera.transform.forward;
			// cameraForward.y = 0;
		
			Vector3 cameraRight = viewCamera.transform.right;
			// cameraRight.y = 0;

			lookDirection = cameraForward * input.z + cameraRight * input.x;

			lookDirection.Normalize();
			lookDirection += transform.position;
		}

		lookDirection.y = transform.position.y;

		Debug.Log(lookDirection);
		transform.LookAt(lookDirection);
	}

	public void Rotate(float angle){
		Vector3 cameraForward = viewCamera.transform.forward;
		cameraForward.y = 0;

		Quaternion rot = Quaternion.LookRotation(cameraForward, Vector3.up);
		rot.eulerAngles += Quaternion.Euler(0, angle, 0).eulerAngles;
		transform.rotation = rot;
		// rot.eulerAngles = angle;
		// transform.rotation = rotation;
	}
}
