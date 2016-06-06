using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class TopDownCamera : MonoBehaviour
{
    private Camera ThisCamera;
    public Transform target;
    public float AngleX;
    public float AngleY;
    public float Distance;


    void Start()
    {
        ThisCamera = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if(!target)
            return;
        transform.LookAt(target);
        Quaternion rotation = Quaternion.Euler(AngleX, AngleY, 0);
        //Distance = Mathf.Clamp(Distance - Input.GetAxis("Mouse ScrollWheel") * scrollSpeed, distanceMin, distanceMax);

        Vector3 negDistance = new Vector3(0.0f, 0.0f, -Distance);
        Vector3 position = rotation * negDistance + target.position;

        transform.rotation = rotation;
        transform.position = position;
    }


}

