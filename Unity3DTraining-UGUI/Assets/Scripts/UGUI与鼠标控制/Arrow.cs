using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    void Update()
    {
        //if (Input.GetMouseButton(0))
        {
            Vector3 mouse = Input.mousePosition;
            Debug.Log("mouse: " + mouse);
            Vector3 obj = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 direction = mouse - obj;
            direction.z = 0f;
            direction = direction.normalized;
            Debug.Log("direction: " + direction);
            //if (direction.y >= 0.4f)
            {
                transform.up = direction;
            }
        }
    }
}
