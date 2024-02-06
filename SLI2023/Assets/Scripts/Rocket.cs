using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public static Rocket instance;
    public Quaternion TargetRot;
    public Vector3 RotationOffset;
    public Vector3 TargetPosition;
 
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = TargetPosition + Vector3.up * 7.621551f;
        transform.rotation = TargetRot;
    }




}
