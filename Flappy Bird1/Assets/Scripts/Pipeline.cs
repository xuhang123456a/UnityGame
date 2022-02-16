using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipeline : MonoBehaviour {
    // 字段
    public float speed;
    public Vector2 range;
    float t = 0;

    void Start () {
        this.Init();
	}

    public void Init()
    {
        float y = Random.Range(range.x, range.y);
        this.transform.localPosition = new Vector3(0, y, 0);
    }

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
