﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoreAI : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed;
    void Update()
    {
        transform.position = Vector3.Lerp(pointA.position, pointB.position, Mathf.Pow(Mathf.Sin(Time.time * speed), 2));
    }
}
