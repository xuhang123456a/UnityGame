using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UGUIDemo01_Game_Player : MonoBehaviour {
    public float speed = 90f;

	private void Update()
    {
        Debug.Log(speed);
        transform.Rotate(Vector3.forward * Time.deltaTime * speed);
    }

    public void OnChangeSpeed(float newSpeed)
    {
        this.speed = newSpeed;
    }
}
