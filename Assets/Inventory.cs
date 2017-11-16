using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public int damage;
	public float speed;
	public float force;

	public GameObject testBullet;

	void Update () {
		if(Input.GetButtonDown("Fire1")){
			Shoot();
		}
	}

	void Shoot(){
		Ray ray = new Ray(transform.position, transform.forward);
		GameObject bullet = Instantiate(testBullet, transform.position, Quaternion.identity);
		bullet.transform.rotation = transform.rotation;
		bullet.GetComponent<Bullet>().Init(damage, speed, force);
	}
}
