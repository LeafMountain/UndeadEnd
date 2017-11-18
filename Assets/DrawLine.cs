using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DrawLine : MonoBehaviour {

	public Transform origin;
	public float duration = 0.1f;
	LineRenderer lineRenderer;

	void Start(){
		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.enabled = false;
	}

	public void _DrawLine(Vector3 toPosition){
		lineRenderer.enabled = true;
		lineRenderer.SetPosition(0, origin.position);
		lineRenderer.SetPosition(1, toPosition);
	}

	IEnumerator RemoveLine(){
		yield return new WaitForSeconds(duration);
		lineRenderer.enabled = false;
	}
}
