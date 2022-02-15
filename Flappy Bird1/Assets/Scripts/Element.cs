using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour {
	public float speed;
	public int direction = 1;
	public SIDE side;
	public float power = 1f;
	void Start () {
		//Destroy(this.gameObject, 30f);
	}
	
	void Update () { 
		this.transform.position += new Vector3(speed * Time.deltaTime * direction, 0,0);

        if (!Screen.safeArea.Contains(Camera.main.WorldToScreenPoint(this.transform.position)))
        {
			//Debug.LogFormat("屏幕信息{2} 世界空间坐标{0}，屏幕坐标{1}",this.transform.position,
			//	Camera.main.WorldToScreenPoint(this.transform.position),Screen.safeArea);
            Destroy(this.gameObject,1f);
        }
	}
}
