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
		// Toggle(false);

		if(origin == null){
			origin = gameObject.transform;
		}

		Refresh();
	}

	public void Refresh(){
		Refresh(origin.transform.position + Vector3.forward * 50);
	}

	public void Refresh(Vector3 position){
		if(color){
			lineRenderer.startColor = color.color;
			lineRenderer.endColor = color.color;
		}

		Toggle(true);
		lineRenderer.SetPosition(1, position);
	}

	public void Toggle(){
		lineRenderer.enabled = !lineRenderer.enabled;
	}

	public void Toggle(bool on){
		lineRenderer.enabled = on;
	}
}
