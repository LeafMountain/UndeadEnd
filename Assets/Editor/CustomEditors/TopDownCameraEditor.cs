using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TopDownCamera))]
public class TopDownCameraEditor : Editor {
	TopDownCamera tar;

	void OnEnable(){
		tar = (TopDownCamera) target;

	}

	public override void OnInspectorGUI(){
		AutoSettings();
		SmoothingSettings();

		if(GUILayout.Button("Update")){
			tar.AutoAdjustCamera();
		}

		EditorGUILayout.Separator();

		//Default inspector
		if(GUI.changed){
			tar.AutoAdjustCamera();
			Undo.RegisterCompleteObjectUndo(tar, "Undo Camera Edit");
		}

		DrawDefaultInspector();
	}

	void AutoSettings(){
		GUILayout.BeginVertical("Box");

		tar.enableAuto = EditorGUILayout.ToggleLeft("Auto Adjust Settings", tar.enableAuto, EditorStyles.boldLabel);
		
		if(tar.enableAuto){
			
			TargetSettings();
			OrientationSettings();
			ZoomSettings();
		}
		
		GUILayout.EndHorizontal();		
	}

	void TargetSettings(){
		EditorGUILayout.Separator();
		EditorGUILayout.LabelField("Target Settings", EditorStyles.boldLabel);
		if(tar.followTarget = EditorGUILayout.Toggle("Follow Target", tar.followTarget)){
			SerializedProperty targets = serializedObject.FindProperty("targets");
			EditorGUILayout.PropertyField(targets, true);
		}
	}

	void OrientationSettings(){
		EditorGUILayout.Separator();
		EditorGUILayout.LabelField("Orientation Settings", EditorStyles.boldLabel);
		tar.pitch = EditorGUILayout.Slider("Pitch", tar.pitch, 0, 360);
		tar.yaw = EditorGUILayout.Slider("Yaw", tar.yaw, 0, 360);
		tar.roll = EditorGUILayout.Slider("Roll", tar.roll, 0, 360);
		
		tar.offset = EditorGUILayout.Vector3Field("Offset", tar.offset);
	}

	void ZoomSettings(){
		EditorGUILayout.Separator();
		EditorGUILayout.LabelField("Zoom Settings", EditorStyles.boldLabel);		

		tar.zoom = EditorGUILayout.Slider("Zoom", tar.zoom, 0, 50);

		if(tar.limitZoom = EditorGUILayout.Toggle("Limit Zoom", tar.limitZoom)){
			GUILayout.BeginHorizontal();
			EditorGUILayout.MinMaxSlider("Zoom min max", ref tar.zoomMinMax.x, ref tar.zoomMinMax.y, 0, 50);
			tar.zoomMinMax.x = EditorGUILayout.FloatField(tar.zoomMinMax.x, GUILayout.Width(23));
			tar.zoomMinMax.y = EditorGUILayout.FloatField(tar.zoomMinMax.y, GUILayout.Width(23));
			GUILayout.EndHorizontal();
		}		
	}

	void SmoothingSettings(){
		GUILayout.BeginVertical("Box");

		tar.enableSmoothing = EditorGUILayout.ToggleLeft("Smooth Settings", tar.enableSmoothing, EditorStyles.boldLabel);

		if(tar.enableSmoothing){
			tar.moveSmoothing = EditorGUILayout.Slider("Move", tar.moveSmoothing, 0, 1);
			tar.moveSmoothing = EditorGUILayout.Slider("Zoom", tar.moveSmoothing, 0, 1);
		}
			
		GUILayout.EndHorizontal();
	}
}
