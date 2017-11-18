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

		if(origin == null){
			origin = gameObject.transform;
		}
	}

	public void _DrawLine(Vector3 toPosition){
		lineRenderer.enabled = true;
		lineRenderer.SetPosition(0, origin.position);
		lineRenderer.SetPosition(1, toPosition);
		
		// Debug.Log(toPosition);
		StartCoroutine("RemoveLine");
	}

	IEnumerator RemoveLine(){
		yield return new WaitForSeconds(duration);
		lineRenderer.enabled = false;
	}
}
