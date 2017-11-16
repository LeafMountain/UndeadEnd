using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public int damage;
	public float speed;
	public float force;

	public GameObject testBullet;
	public Transform bulletOrigin;

	void Update () {
		if(Input.GetButtonDown("RightTrigger")){
			Shoot();
		}
	}

	void Shoot(){
		Ray ray = new Ray(transform.position, transform.forward);
		GameObject bullet = Instantiate(testBullet, bulletOrigin.position, bulletOrigin.rotation);
	}
}
