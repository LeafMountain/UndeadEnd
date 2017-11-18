using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shooter : MonoBehaviour {

	public Transform origin;
	public float range = 1;

	public UnityEvent OnShoot;
	public UnityTriggerEvent OnHitTarget;
	public UnityPositionEvent onHitPosition;

	void Start(){
		if(!origin){
			origin = transform;
		}
	}

	public void Shoot(){
		Ray shootRay = new Ray(origin.position, transform.forward);
		RaycastHit hit;

		Debug.DrawRay(shootRay.origin, shootRay.direction * range, Color.red, .1f);

		Physics.Raycast(shootRay, out hit, range);

		OnShoot.Invoke();

		onHitPosition.Invoke(shootRay.origin + shootRay.direction * range);

		if(hit.transform){
			Collider col = hit.transform.GetComponent<Collider>();

			if(col){
				OnHitTarget.Invoke(col);
			}
		}
	}
}

[System.Serializable]
public class UnityPositionEvent : UnityEvent<Vector3> {}
