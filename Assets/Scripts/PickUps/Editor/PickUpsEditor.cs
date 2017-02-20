using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(PickUps))]
public class PickUpsEditor : Editor {

	public override void OnInspectorGUI(){
		DrawDefaultInspector();

		EditorGUILayout.HelpBox("This is a help box", MessageType.Info);
	}
}
