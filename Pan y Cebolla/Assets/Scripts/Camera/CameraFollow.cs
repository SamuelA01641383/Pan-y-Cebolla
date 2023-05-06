using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float Speed = 2f;
    public Transform target;
    public float yOffset = 1f;


    void Update()
    {
        Vector3 newpos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newpos, Speed * Time.deltaTime);
    }
}
