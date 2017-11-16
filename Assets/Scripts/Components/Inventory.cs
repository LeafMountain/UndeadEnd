using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public GameObject testBullet;
	public Transform bulletOrigin;

	public void Shoot(){
		Ray ray = new Ray(transform.position, transform.forward);
		GameObject bullet = Instantiate(testBullet, bulletOrigin.position, bulletOrigin.rotation);
	}
}
