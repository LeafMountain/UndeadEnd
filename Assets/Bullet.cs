using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Bullet : MonoBehaviour {

	int damage;
	float speed;
	float force;

	public void Init(int damage, float speed, float force){
		this.damage = damage;
		this.speed = speed;
		this.force = force;
	}

	public void Hit (Collider col) {
		Health health = col.GetComponent<Health>();

		if(health){
			health.Damage(damage);
		}

		Destroy(gameObject);
	}

	void Update(){
		transform.Translate(Vector3.forward * speed);
	}
}
