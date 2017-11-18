using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour {

	public GameObject instantiatedObject;
	public Transform position;
	public Transform rotation;

	public void Instantiate(){
		GameObject.Instantiate(instantiatedObject, position.position, rotation.rotation);
	}
}
