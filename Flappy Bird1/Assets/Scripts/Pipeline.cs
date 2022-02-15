using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipeline : MonoBehaviour {
    public float speed;
    public Vector2 range;
	// Use this for initialization
	void Start () {
        this.Init();
	}

    float t = 0;

    public void Init()
    {
        float y = Random.Range(range.x, range.y);
        this.transform.localPosition = new Vector3(0, y, 0);
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.position += new Vector3(-speed, 0) * Time.deltaTime;
        t += Time.deltaTime;
        if (t > 6f)
        {
            t = 0;
            this.Init();
        }
    }
}
