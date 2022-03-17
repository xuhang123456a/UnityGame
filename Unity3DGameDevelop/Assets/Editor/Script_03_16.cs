using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Camera))]
public class Script_03_16 : Editor {
	void OnSceneGUI()
    {
        Camera camera = target as Camera;
        if (camera != null)
        {
            Handles.color = Color.red;
            Handles.Label(camera.transform.position, camera.transform.position.ToString());

            Handles.BeginGUI();
            GUI.backgroundColor = Color.red;
            if (GUILayout.Button("click", GUILayout.Width(200f)))
            {
                Debug.LogFormat("click = {0}", camera.name);
            }
            GUILayout.Label("Label");
            Handles.EndGUI();
        }
    }
}
