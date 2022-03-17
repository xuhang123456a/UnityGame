using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_03_15 : MonoBehaviour
{
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        //画线
        Gizmos.DrawLine(transform.position, Vector3.one);
        //立方体
        Gizmos.DrawCube(Vector3.one, Vector3.one);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 1);
    }
}