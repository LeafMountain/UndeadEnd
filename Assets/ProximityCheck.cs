using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityCheck : MonoBehaviour {

	public enum CheckMode { Raycast, SphereOverlap }
	public Object types;
	public float range;

	public void GetProximityItems(){
		// Object test = types.GetType();
	}

	void RaycastCheck(){
		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;

		Physics.Raycast(ray, out hit, range);
	}

	void SphereOverlapCheck(){
		Physics.OverlapSphere(transform.position, range);

	}
}
