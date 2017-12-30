using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine.Events;

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
		ToggleFoldOut("Auto Adjust Settings", ref tar.enableAuto, () => AutoSettings());
		ToggleFoldOut("Smoothing Settings", ref tar.enableSmoothing, () => SmoothingSettings());
		ToggleFoldOut("Shader Settings", ref tar.enableReplacementShader, () => ShaderSettings());

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
		TargetSettings();
		OrientationSettings();
		ToggleFoldOut("Adjust Zoom", ref tar.enableZoom, () => ZoomSettings());
	}

	void TargetSettings(){
		EditorGUILayout.LabelField("Target Settings", EditorStyles.boldLabel);
		tars.DoLayoutList();
	}

	void OrientationSettings(){
		EditorGUILayout.LabelField("Orientation Settings", EditorStyles.boldLabel);
		tar.pitch = EditorGUILayout.Slider("Pitch", tar.pitch, 0, 360);
		tar.yaw = EditorGUILayout.Slider("Yaw", tar.yaw, 0, 360);
		tar.roll = EditorGUILayout.Slider("Roll", tar.roll, 0, 360);
		
		tar.offset = EditorGUILayout.Vector3Field("Offset", tar.offset);
	}

	void ZoomSettings(){
		tar.encapsulationZoom = EditorGUILayout.Toggle("Encapsulation Zoom", tar.encapsulationZoom);
		
		if(!tar.encapsulationZoom){
			tar.zoom = EditorGUILayout.Slider("Zoom", tar.zoom, 0, 50);
		}

		if(tar.limitZoom = EditorGUILayout.Toggle("Limit Zoom", tar.limitZoom)){
			GUILayout.BeginHorizontal();
			EditorGUILayout.MinMaxSlider("Zoom min max", ref tar.zoomMinMax.x, ref tar.zoomMinMax.y, 0, 50);
			tar.zoomMinMax.x = EditorGUILayout.FloatField(tar.zoomMinMax.x, GUILayout.Width(23));
			tar.zoomMinMax.y = EditorGUILayout.FloatField(tar.zoomMinMax.y, GUILayout.Width(23));
			GUILayout.EndHorizontal();
		}		
	}

	void SmoothingSettings(){
		tar.smoothing = EditorGUILayout.Slider("Value", tar.smoothing, 0, 1);
	}

	void ShaderSettings(){
		tar.replacementShader = (Shader)EditorGUILayout.ObjectField("Shader", tar.replacementShader, typeof(Shader), false);
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

	bool ToggleFoldOut(string title, ref bool toggle, UnityAction action){
		// EditorGUILayout.Separator();
		
		GUILayout.BeginVertical("Box");
		toggle = EditorGUILayout.BeginToggleGroup(title, toggle);

		if(toggle){
			action.Invoke();
		}

		EditorGUILayout.EndToggleGroup();
		GUILayout.EndVertical();
		
		return toggle;
	}
}