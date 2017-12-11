using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public Object scene;
	public bool loadOnStart;

	[Range(0, 1)]
	public float loadPercentage;

	AsyncOperation asyncOperation;
	bool sceneLoading;

	void Start(){
		if(loadOnStart){
			LoadScene();
		}
	}

	public void LoadScene(){
		StartCoroutine("LoadSceneProgress");
	}

	public void Trigger(){
		if(asyncOperation.progress != 0){
			asyncOperation.allowSceneActivation = true;
		}
	}

	IEnumerator LoadSceneProgress(){
		yield return new WaitForSeconds(1);

		asyncOperation = SceneManager.LoadSceneAsync(scene.name);
		asyncOperation.allowSceneActivation = false;

		while(asyncOperation.progress != 0.9f){
			loadPercentage = asyncOperation.progress;
			yield return null;
		}

		loadPercentage = 1;
	}
}
