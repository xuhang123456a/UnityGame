using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;

//[CustomEditor(typeof(Transform))]
public class Script_03_10:Editor
{
    private Editor m_Editor;
    void OnEnable()
    {
        m_Editor = Editor.CreateEditor(target, Assembly.GetAssembly(typeof(Editor)).GetType("UnityEditor.TransformInspector", true));
    }

    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("拓展按钮"))
        {

        }
        m_Editor.OnInspectorGUI();
        //base.OnInspectorGUI();
    }
}