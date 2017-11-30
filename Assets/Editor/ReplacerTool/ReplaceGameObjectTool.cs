using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ReplaceGameObjectTool : EditorWindow {

	GameObject replacer;

	[MenuItem("Window/Replace")]
	public static void ShowWindow(){
		EditorWindow.GetWindow<ReplaceGameObjectTool>("Replace");
	}

	void OnGUI(){
		GUILayout.Label("Game Object to replace selection", EditorStyles.boldLabel);

		replacer = (GameObject)EditorGUILayout.ObjectField(replacer, typeof(GameObject));

		if(GUILayout.Button("Replace Selected Game Objects")){

			if(replacer){
				foreach(GameObject go in Selection.gameObjects){
					Vector3 pos = go.transform.position;
					Quaternion rot = go.transform.rotation;
					// Vector3 scale = go.transform.localScale;
					Transform parent = go.transform.parent;
					string name = go.name;

					DestroyImmediate(go);

					// GameObject newGo = Instantiate(replacer, pos, rot, parent);
					GameObject prefab = PrefabUtility.InstantiatePrefab(replacer) as GameObject;
					prefab.transform.position = pos;
					prefab.transform.rotation = rot;
					prefab.transform.parent = parent;
					prefab.name = name;
					
					// newGo.transform.localScale = scale;
				}
			} else {
				Debug.Log("No item to replace with");
			}
		}
	}
	
}
