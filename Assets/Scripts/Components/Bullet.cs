using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class Bullet : MonoBehaviour {

	int damage;
	float speed;
	float force;

	Rigidbody rigidbody;

	public void Init(int damage, float speed, float force){
		this.damage = damage;
		this.speed = speed;
		this.force = force;
		rigidbody = GetComponent<Rigidbody>();
	}

	public void Hit (Collider col) {
		Debug.Log(col.name);
		Health health = col.GetComponent<Health>();

		if(health){
			health.Damage(damage);
		}

		Destroy(gameObject);
	}

	void FixedUpdate(){
		// rigidbody.MovePosition(Vector3.forward * speed);
		rigidbody.AddForce(transform.forward * speed, ForceMode.VelocityChange);
	}
}