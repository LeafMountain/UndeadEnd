using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(TagFilter))]
public class TagFilterEditor : Editor {

	ReorderableList listOfTagChecks;

	private void OnEnable() {
        listOfTagChecks = new ReorderableList(serializedObject, serializedObject.FindProperty("checks"), true, true, true, true);

		// listOfTagChecks.elementHeight = 110;

        listOfTagChecks.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) => {            
            SerializedProperty element = listOfTagChecks.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;

		    listOfTagChecks.elementHeight = 110;            

            EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("tag"), GUIContent.none);
            EditorGUI.PropertyField(new Rect(rect.x, rect.y + EditorGUIUtility.singleLineHeight + 2, rect.width, 100), element.FindPropertyRelative("acceptedTagFound"), GUIContent.none);
        };

        listOfTagChecks.onAddCallback = (ReorderableList list) => {
            int index = list.serializedProperty.arraySize;
            list.serializedProperty.arraySize++;
            list.index = index;
            SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index);
            element.FindPropertyRelative("tag").objectReferenceValue = null;
			// element.FindPropertyRelative("acceptedTagFound").objectReferenceValue = null;
        };

        // listOfTagChecks.onAddDropdownCallback = (Rect buttonRect, ReorderableList list) => {  
        //     GenericMenu menu = new GenericMenu();
        //     string assetPath = "Assets/Data/Tags";

        //     string[] guids = AssetDatabase.FindAssets("", new[]{assetPath});
            
        //     foreach (var guid in guids) {
        //         string _path = AssetDatabase.GUIDToAssetPath(guid);
        //         menu.AddItem(new GUIContent(Path.GetFileNameWithoutExtension(_path)), false, clickHandler, new TagCheckParams() {Path = _path});
        //     }

        //     menu.ShowAsContext();
        // };
    }

	public override void OnInspectorGUI()
    {
		serializedObject.Update();
        listOfTagChecks.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }

    private void clickHandler(object target) {

        // TagCheckParams data = (TagCheckParams)target;
        // int index = listOfTagChecks.serializedProperty.arraySize;
        // listOfTagChecks.serializedProperty.arraySize++;

        // listOfTagChecks.index = index;
        // SerializedProperty element = listOfTagChecks.serializedProperty.GetArrayElementAtIndex(index);
        // element.objectReferenceValue = AssetDatabase.LoadAssetAtPath(data.Path, typeof(TagCheck)) as TagCheck;
        // serializedObject.ApplyModifiedProperties();
    }

    private struct TagCheckParams {  
        public string Path;
    }
}
