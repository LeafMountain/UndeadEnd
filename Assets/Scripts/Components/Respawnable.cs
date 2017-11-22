using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawnable : MonoBehaviour {

	public Vector3 spawnPoint;

	void Start(){
		if(spawnPoint == Vector3.zero){
			spawnPoint = transform.position;
		}
	}

	public void Respawn(){
		transform.position = spawnPoint;
	}

	public void SetSpawnPoint(Vector3 spawnPoint){
		this.spawnPoint = spawnPoint;
	}
}
