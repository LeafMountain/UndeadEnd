using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collector : MonoBehaviour {

	public UnityGameObjectEvent OnCollected;

	public void Collect(GameObject collectable){
		OnCollected.Invoke(collectable);
	}
}