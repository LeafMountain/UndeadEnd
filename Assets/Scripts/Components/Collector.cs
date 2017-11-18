using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collector : MonoBehaviour {

	public UnityCollectableEvent OnCollected;

	public void Collect(Collectable collectable){
		OnCollected.Invoke(collectable);
	}
}

[System.Serializable]
public class UnityCollectableEvent : UnityEvent<Collectable> {}
