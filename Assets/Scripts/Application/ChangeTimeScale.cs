using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTimeScale : MonoBehaviour {

	public float timeScale;

	public void Trigger(){
		Time.timeScale = timeScale;
	}
}
