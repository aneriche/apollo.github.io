﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitScript : MonoBehaviour
{
    public Transform CenterPoint;
    public float OrbitSpeed;

    private void FixedUpdate()
    {
        // planet to travel along a path that rotates around the sun
        //transform.RotateAround(CenterPoint.transform.position, Vector3.up, OrbitSpeed);
        transform.position = RotatePointAroundPivot(transform.position, CenterPoint.transform.position, Quaternion.Euler(0, OrbitSpeed, 0));
    }
    public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion angle)
    {
        return angle * (point - pivot) + pivot;
    }
}
