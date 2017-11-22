using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour {

	public float force;
	public Transform location;
	public float radius;

	void Start(){
		if(!location){
			location = transform;
		}
	}

	public void AddForceAtLocation(){
		_AddForceAtLocation(transform.position);
	}

	public void AddForceAtLocation(Vector3 position){
		_AddForceAtLocation(position);
	}

	public void AddForceAtLocation(Collider col){
		_AddForceAtLocation(col.transform.position);
	}

	void _AddForceAtLocation(Vector3 position){
		Collider[] colliders = Physics.OverlapSphere(position, radius);

		for (int i = 0; i < colliders.Length; i++)
		{
			Rigidbody rigidbody = colliders[i].GetComponent<Rigidbody>();

			if(rigidbody){
				rigidbody.AddForce((position - rigidbody.transform.position) * force, ForceMode.Impulse);
			}
		}
	}
}
