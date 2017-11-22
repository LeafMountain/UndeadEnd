using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyParent : MonoBehaviour {

	public Transform parent;
	public bool resetTransform;

	public void SetParent(GameObject go){
		SetParent(go.transform);
	}

	public void SetParent(Transform child){
		if(resetTransform){
			child.position = Vector3.zero;
			child.rotation = Quaternion.identity;
		}

		child.SetParent(parent, !resetTransform);
	}

	public void RemoveParent(GameObject go){
		RemoveParent(go.transform);
	}

	public void RemoveParent(Transform child){
		child.SetParent(null);
	}
}
