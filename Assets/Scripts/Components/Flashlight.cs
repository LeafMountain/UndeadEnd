using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {

	public bool useViewAngle;
	public bool useViewRadius;
	public Light light;

	public bool lightToggle = true;

	FieldOfView fov;

	void Start(){
		fov = GetComponent<FieldOfView>();
	}

	void Update () {
		if(fov){
			if(light.range != fov.radius){
				light.range = fov.radius;
			}
			if(light.spotAngle != fov.viewAngle){
				light.spotAngle = fov.viewAngle;
			}
		}
	}

	public void ToggleLight(){
		light.enabled = !light.enabled;
	}
}
