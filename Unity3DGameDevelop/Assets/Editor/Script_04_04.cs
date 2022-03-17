using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_04_04 : MonoBehaviour 
{
	public GameObject cube;
	void Start () {
		StartCoroutine(CreateCube());
	}
	
	IEnumerator CreateCube()
    {
		for(int i = 0; i < 100; i++)
        {
			Instantiate(cube,new Vector3(i,0,0),Quaternion.identity);
			yield return new WaitForSeconds(1f);
        }
    }
}
