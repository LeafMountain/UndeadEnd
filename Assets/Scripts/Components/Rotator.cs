using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	public void Rotate(Vector3 lookDirection, bool globalDirection){
		if(!globalDirection){
			lookDirection += transform.position;
		}

		lookDirection.y = transform.position.y;

		transform.LookAt(lookDirection);
	}
}
