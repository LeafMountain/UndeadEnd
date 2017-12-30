using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(CameraController))]
public class TopDownCameraEditor : Editor {
	CameraController tar;
	ReorderableList tars;

	bool drawDefaultInspector;

	void OnEnable(){
		tar = (CameraController) target;
		tars = CreateList("targets", "Targets");
	}

	public override void OnInspectorGUI(){
		serializedObject.Update();
		AutoSettings();
		SmoothingSettings();
		ShaderSettings();

		if(GUILayout.Button("Update")){
			tar.AutoAdjustCamera();
		}

		EditorGUILayout.Separator();

		//Default inspector
		if(GUI.changed){
			tar.AutoAdjustCamera();
			Undo.RegisterCompleteObjectUndo(tar, "Undo Camera Edit");
		}

		serializedObject.ApplyModifiedProperties();

		if(drawDefaultInspector = EditorGUILayout.ToggleLeft("Draw Default Inspector", drawDefaultInspector, EditorStyles.boldLabel)){
			DrawDefaultInspector();
		}
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
		tars.DoLayoutList();
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

		tar.autoZoom = EditorGUILayout.ToggleLeft("Adjust Zoom", tar.autoZoom, EditorStyles.boldLabel);
		
		if(tar.autoZoom){
			tar.zoom = EditorGUILayout.Slider("Zoom", tar.zoom, 0, 50);

			if(tar.limitZoom = EditorGUILayout.Toggle("Limit Zoom", tar.limitZoom)){
				GUILayout.BeginHorizontal();
				EditorGUILayout.MinMaxSlider("Zoom min max", ref tar.zoomMinMax.x, ref tar.zoomMinMax.y, 0, 50);
				tar.zoomMinMax.x = EditorGUILayout.FloatField(tar.zoomMinMax.x, GUILayout.Width(23));
				tar.zoomMinMax.y = EditorGUILayout.FloatField(tar.zoomMinMax.y, GUILayout.Width(23));
				GUILayout.EndHorizontal();
			}
		}
	}

	void SmoothingSettings(){
		GUILayout.BeginVertical("Box");

		tar.enableSmoothing = EditorGUILayout.ToggleLeft("Smooth Settings", tar.enableSmoothing, EditorStyles.boldLabel);

		if(tar.enableSmoothing){
			tar.smoothing = EditorGUILayout.Slider("Value", tar.smoothing, 0, 1);
		}
			
		GUILayout.EndHorizontal();
	}

	void ShaderSettings(){
		GUILayout.BeginVertical("Box");

		tar.enableReplacementShader = EditorGUILayout.ToggleLeft("Replacement Shader Settings", tar.enableReplacementShader, EditorStyles.boldLabel);
		
		if(tar.enableReplacementShader){
			tar.replacementShader = (Shader)EditorGUILayout.ObjectField("Shader", tar.replacementShader, typeof(Shader), false);
		}
		
		GUILayout.EndHorizontal();	
	}

	ReorderableList CreateList(string listName, string label){
        ReorderableList list = new ReorderableList(serializedObject, serializedObject.FindProperty(listName), true, true, true, true);

        list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) => {            
            SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;

            EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight), element, GUIContent.none);
        };

        list.onAddCallback = (ReorderableList _list) => {
            int index = _list.serializedProperty.arraySize;
            _list.serializedProperty.arraySize++;
            _list.index = index;
            SerializedProperty element = _list.serializedProperty.GetArrayElementAtIndex(index);

            element.objectReferenceValue = null;
        };

        list.drawHeaderCallback = (Rect rect) => {  
            EditorGUI.LabelField(rect, label);
        };
        
        return list;
    }
}
