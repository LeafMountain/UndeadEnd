using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DrawLine : MonoBehaviour {

	public Transform origin;
	public ColorVariable color;

	LineRenderer lineRenderer;

	void Start(){
		lineRenderer = GetComponent<LineRenderer>();

		if(origin == null){
			origin = gameObject.transform;
		}

		Refresh();
	}

	public void Refresh(){
		Refresh(transform.forward * 100);
	}

	public void Refresh(Vector3 position){
		if(color){
			lineRenderer.startColor = color.color;
			lineRenderer.endColor = color.color;
		}

		lineRenderer.SetPosition(1, position);
	}
}
