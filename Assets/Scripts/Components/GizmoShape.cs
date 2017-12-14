using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GizmoShape : MonoBehaviour {
	public string label;
	public Color labelColor = Color.white;

	
	public enum Shape { Cube, Sphere }

	public Shape shape = Shape.Cube;
	public Color gizmoColor = Color.black;
	public Vector3 size = Vector3.one;

	void OnDrawGizmos(){
		Gizmos.color = gizmoColor;

		Matrix4x4 originalMatix = Gizmos.matrix;
		Matrix4x4 cubeTransform = Matrix4x4.TRS(transform.position, transform.rotation, size);
		Gizmos.matrix *= cubeTransform;
		
		if(shape == Shape.Cube){
			Gizmos.DrawCube(Vector3.zero, transform.localScale);
		} else if(shape == Shape.Sphere) {
			Gizmos.DrawSphere(Vector3.zero, transform.localScale.magnitude / 2);
		}

		Gizmos.matrix = originalMatix;
	}
}
