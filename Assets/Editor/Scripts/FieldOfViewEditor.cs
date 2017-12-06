using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FieldOfView))]
public class FieldOfViewEditor : Editor {

	void OnSceneGUI(){
		FieldOfView fov = (FieldOfView)target;

		Handles.color = Color.white;
		Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.radius);

		Vector3 angleA = fov.DirFromAngle(-fov.viewAngle / 2, false);
		Vector3 angleB = fov.DirFromAngle(fov.viewAngle / 2, false);

		
		Handles.DrawLine(fov.transform.position, fov.transform.position + angleA * fov.radius);
		Handles.DrawLine(fov.transform.position, fov.transform.position + angleB * fov.radius);

		// foreach(Transform target in fov.visibleTargets){
		// 	Debug.DrawLine(fov.transform.position, target.position, Color.red);
		// }
	}
}
