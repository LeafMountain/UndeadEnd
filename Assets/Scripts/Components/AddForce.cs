using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AddForce : MonoBehaviour {

	public enum ForcePosition { Self, Location }
	public enum ForceUpdate { Once, Continous }
	public enum RelativeTo { World, Camera, Self }

	public ForceMode mode;
	public ForcePosition position;
	public ForceUpdate update;
	public RelativeTo relativeTo;

	public bool addOnStart;

	public Vector3 force;
	public Transform location;
	public float radius;

	Rigidbody rb;

	void Start(){
		rb = GetComponent<Rigidbody>();

		if(!location){
			location = transform;
		}

		if(addOnStart){
			_AddForce();
		}
	}

	void Update(){
		if(update == ForceUpdate.Continous){
			_AddForce();
		}
	}

	public void Trigger(){
		_AddForce();
	}

	void _AddForce(){
		Vector3 calculatedForce = force;

		switch (relativeTo){
			case (RelativeTo.Camera) :
				calculatedForce = ConvertToCameraForward(force);
				break;
			case (RelativeTo.Self) :
				calculatedForce = ConvertToSelfForward(force);
				break;
		}

		switch (position) {
			case (ForcePosition.Self) :
				rb.AddForce(calculatedForce, mode);
				break;
			case (ForcePosition.Location) :
				// rigidbody.AddForceAtPosition(calculatedForce, location.position, mode);
				AddForceAtLocation();
				break;
		}
	}

	void AddForceAtLocation(){
		Collider[] colliders = Physics.OverlapSphere(location.position, radius);

		for (int i = 0; i < colliders.Length; i++)
		{
			Rigidbody rb = colliders[i].GetComponent<Rigidbody>();

			if(rb){
				rb.AddForce(force, mode);
			}
		}
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
