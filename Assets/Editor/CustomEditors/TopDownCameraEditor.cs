using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TopDownCamera))]
public class TopDownCameraEditor : Editor {
	TopDownCamera tar;

	public override void OnInspectorGUI(){
		tar = (TopDownCamera) target;

		tar.pointOfView = (TopDownCamera.PointOfView) EditorGUILayout.EnumPopup("Perspective", tar.pointOfView);

		EditorGUILayout.Separator();

		switch (tar.pointOfView)
		{
			case (TopDownCamera.PointOfView.FirstPerson):
				FirstPersonEditor();
				break;
			case (TopDownCamera.PointOfView.ThirdPerson):
				ThirdPersonEditor();
				break;
			case (TopDownCamera.PointOfView.FreeMovement):
				FreeMovementEditor();
				break;
		}

		if(GUILayout.Button("Update")){
			tar.AdjustCamera();
		}

		EditorGUILayout.Separator();

		//Default inspector
		if(GUI.changed){
			tar.AdjustCamera();
			Undo.RegisterCompleteObjectUndo(tar, "Undo Camera Edit");
		}

		// DrawDefaultInspector();
	}

	void FirstPersonEditor(){
		tar.target = (Transform)EditorGUILayout.ObjectField("Target", tar.target, typeof(Transform), true);
		tar.height = EditorGUILayout.Slider("Height", tar.yaw, 0, 50);
	}

	void ThirdPersonEditor(){
		if(tar.followTarget = EditorGUILayout.Toggle("Follow Target", tar.followTarget)){
			tar.target = (Transform)EditorGUILayout.ObjectField("Target", tar.target, typeof(Transform), true);
		}
		
		tar.zoom = EditorGUILayout.Slider("Zoom", tar.zoom, 0, 50);		
		if(tar.limitZoom = EditorGUILayout.Toggle("Limit Zoom", tar.limitZoom)){
			GUILayout.BeginHorizontal();
			EditorGUILayout.MinMaxSlider("Zoom min max", ref tar.zoomMinMax.x, ref tar.zoomMinMax.y, 0, 50);
			tar.zoomMinMax.x = EditorGUILayout.FloatField(tar.zoomMinMax.x, GUILayout.Width(23));
			tar.zoomMinMax.y = EditorGUILayout.FloatField(tar.zoomMinMax.y, GUILayout.Width(23));
			GUILayout.EndHorizontal();
		}

		tar.pitch = EditorGUILayout.Slider("Pitch", tar.pitch, 0, 90);
		tar.yaw = EditorGUILayout.Slider("Yaw", tar.yaw, 0, 360);
	}

	void FreeMovementEditor(){

	}

	void UseSmoothing(){

	}
}
