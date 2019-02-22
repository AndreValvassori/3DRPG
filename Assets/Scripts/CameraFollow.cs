using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float SmoothSpeed = 0.125f;

    private Vector3 velocity = Vector3.zero;

    public int MinFieldOfView;
    public int MaxFieldOfView;
    public float CamZoomMultiplier;

    public Vector3 offset;

    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position,desiredPosition,ref velocity,SmoothSpeed);


        var d = Input.GetAxis("Mouse ScrollWheel");

        if (d > 0f)
        {
            Debug.Log("Scroll Up " +d);
           
            if (cam.fieldOfView >= MinFieldOfView)
            {
                cam.fieldOfView = cam.fieldOfView-(d* CamZoomMultiplier);
            }
        }
        else if (d < 0f)
        {
            Debug.Log(d);
            if (cam.fieldOfView <= MaxFieldOfView)
            {
                cam.fieldOfView = cam.fieldOfView + ((d*-1) * CamZoomMultiplier);
            }
        }

    }
}
