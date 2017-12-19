using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(Animate))]
public class AnimateEditor : Editor {

	List<ReorderableList> lists = new List<ReorderableList>();

	private void OnEnable() {
        lists.Add(CreateList("floats", "name", "value"));
        lists.Add(CreateList("ints", "name", "value"));
        lists.Add(CreateList("bools", "name", "value"));
        lists.Add(CreateList("triggers", "name", "gameEvent"));        
    }

    ReorderableList CreateList(string listName, string property1, string property2){
        ReorderableList list = new ReorderableList(serializedObject, serializedObject.FindProperty(listName), true, true, true, true);

        list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) => {            
            SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;

		    list.elementHeight = EditorGUIUtility.singleLineHeight * 2 + 4;        

            EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative(property1), GUIContent.none);

            EditorGUI.PropertyField(new Rect(rect.x, rect.y + EditorGUIUtility.singleLineHeight + 2, rect.width, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative(property2), GUIContent.none);
        };

        list.onAddCallback = (ReorderableList _list) => {
            int index = _list.serializedProperty.arraySize;
            _list.serializedProperty.arraySize++;
            _list.index = index;
            SerializedProperty element = _list.serializedProperty.GetArrayElementAtIndex(index);

            // element.objectReferenceValue = null;
        };

        list.drawHeaderCallback = (Rect rect) => {  
            EditorGUI.LabelField(rect, listName);
        };

        list.onCanRemoveCallback = (ReorderableList _list) => { 
            ReorderableList.defaultBehaviours.DoRemoveButton(_list);
            return _list.count > 1;
        };
        
        return list;
    }

	public override void OnInspectorGUI()
    {
		serializedObject.Update();
        for (int i = 0; i < lists.Count; i++)
        {
            lists[i].DoLayoutList();            
        }
        serializedObject.ApplyModifiedProperties();
    }

    // private void clickHandler(object target) {

    //     TagParams data = (TagParams)target;
    //     int index = list.serializedProperty.arraySize;
    //     list.serializedProperty.arraySize++;

    //     list.index = index;
    //     SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index);
    //     element.objectReferenceValue = AssetDatabase.LoadAssetAtPath(data.Path, typeof(Tag)) as Tag;
    //     serializedObject.ApplyModifiedProperties();
    // }

    // private struct TagParams {  
    //     public string Path;
    // }
}
