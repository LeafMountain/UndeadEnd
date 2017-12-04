using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TopDownCamera))]
public class TopDownCameraEditor : Editor {

	public override void OnInspectorGUI(){
		TopDownCamera tar = (TopDownCamera) target;

		if(GUILayout.Button("Update")){
			tar.AdjustCamera();
		}

		//Default inspector
		if(DrawDefaultInspector()){
			tar.AdjustCamera();
		}
	}
}
