using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour {

	public UnityGameObjectEvent OnTrigger;

	public void Raise(GameObject go){
		if(OnTrigger != null){
			OnTrigger.Invoke(go);
		}
	}

}
