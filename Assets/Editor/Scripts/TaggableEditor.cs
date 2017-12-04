using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(Taggable))]
public class TaggableEditor : Editor {

	ReorderableList listOfTags;

	private void OnEnable() {
        listOfTags = new ReorderableList(serializedObject, serializedObject.FindProperty("tags"), true, true, true, true);

        listOfTags.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) => {
            SerializedProperty element = listOfTags.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;

            EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight), element, GUIContent.none);
        };

        listOfTags.onAddCallback = (ReorderableList list) => {
            int index = list.serializedProperty.arraySize;
            list.serializedProperty.arraySize++;
            list.index = index;
            SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index);

            element.objectReferenceValue = null;
        };

        listOfTags.onAddDropdownCallback = (Rect buttonRect, ReorderableList list) => {  
            GenericMenu menu = new GenericMenu();
            string assetPath = "Assets/Data/Tags";

            string[] guids = AssetDatabase.FindAssets("", new[]{assetPath});
            
            foreach (var guid in guids) {
                string _path = AssetDatabase.GUIDToAssetPath(guid);
                menu.AddItem(new GUIContent(Path.GetFileNameWithoutExtension(_path)), false, clickHandler, new TagParams() {Path = _path});
            }

            menu.ShowAsContext();
        };

        listOfTags.drawHeaderCallback = (Rect rect) => {  
            EditorGUI.LabelField(rect, "Tags");
        };
    }

	public override void OnInspectorGUI()
    {
		serializedObject.Update();
        listOfTags.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }

    private void clickHandler(object target) {

        TagParams data = (TagParams)target;
        int index = listOfTags.serializedProperty.arraySize;
        listOfTags.serializedProperty.arraySize++;

        listOfTags.index = index;
        SerializedProperty element = listOfTags.serializedProperty.GetArrayElementAtIndex(index);
        element.objectReferenceValue = AssetDatabase.LoadAssetAtPath(data.Path, typeof(Tag)) as Tag;
        serializedObject.ApplyModifiedProperties();
    }

    private struct TagParams {  
        public string Path;
    }
}
