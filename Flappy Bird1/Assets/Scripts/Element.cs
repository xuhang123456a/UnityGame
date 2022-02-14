using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour {
	public float speed;
	public int direction = 1;
	void Start () {
		//Destroy(this.gameObject, 30f);
	}
	
	void Update () { 
		this.transform.position += new Vector3(speed * Time.deltaTime * direction, 0,0);

        if (Screen.safeArea.Contains(Camera.main.WorldToScreenPoint(this.transform.position)))
        {
			Debug.LogWarning("删除了"+ this.transform.position+"  " + Camera.main.WorldToScreenPoint(this.transform.position));
            Destroy(this.gameObject, 1f);
        }
	}
}
