using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Useable : MonoBehaviour {

	public UnityEvent onUse;

	public void Use(){
		onUse.Invoke();
	}
}
