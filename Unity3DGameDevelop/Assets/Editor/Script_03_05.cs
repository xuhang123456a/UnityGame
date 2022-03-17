using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Script_03_05
{
	[MenuItem("GameObject/My Create/Cube",false,0)]
	static void CreateCube()
    {
		GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
		go.transform.position = new Vector3(0, 0, 0);
    }
}