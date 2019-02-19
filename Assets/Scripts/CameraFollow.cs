using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float SmoothSpeed = 0.125f;
    private Vector3 velocity = Vector3.zero;

    public Vector3 offset;
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);
        transform.position = Vector3.SmoothDamp(transform.position,desiredPosition,ref velocity,SmoothSpeed);
    }
}
