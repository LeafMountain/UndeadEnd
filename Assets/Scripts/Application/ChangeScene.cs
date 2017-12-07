using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public Object scene;

	public void Trigger(){
		SceneManager.LoadScene(scene.name);
	}
}
