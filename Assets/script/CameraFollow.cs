using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float speedCamera;
    public Transform TargetPos;   

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(TargetPos.position.x, TargetPos.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, speedCamera*Time.deltaTime);
    }
}
