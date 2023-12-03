using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public static Rocket instance;
    public AltitudeDisplay AD;
    public float InterpalationSmoothness = 2f;
    public Vector3 TargetRot;
    public Vector3 RotationOffset;
 
    List<Vector3> Data = new List<Vector3>();
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        float CurrentX = Mathf.LerpAngle(transform.eulerAngles.x, TargetRot.x, InterpalationSmoothness * Time.deltaTime);
        float CurrentY = Mathf.LerpAngle(transform.eulerAngles.y, TargetRot.y, InterpalationSmoothness * Time.deltaTime);
        float CurrentZ = Mathf.LerpAngle(transform.eulerAngles.z, TargetRot.z, InterpalationSmoothness * Time.deltaTime);
        transform.eulerAngles = new Vector3(CurrentX, CurrentY, CurrentZ);
    }

    public static void UpdateData(string Data)
    {
        string[] RealData = Data.Split('|');
        float mx = -1;
        float my = -1;
        foreach (string d in RealData)
        {
            if (d.StartsWith("mx"))
            {
                string magnetometer = d.Substring(2);
                mx = float.Parse(magnetometer);
            }
            if (d.StartsWith("my"))
            {
                string magnetometer = d.Substring(2);
                my = float.Parse(magnetometer);
            }
            if (d.StartsWith("gy"))
            {
                string gyro = d.Substring(2);
                Rocket.instance.TargetRot.x = float.Parse(gyro);
            }
            if (d.StartsWith("gz"))
            {
                string gyro = d.Substring(2);
                Rocket.instance.TargetRot.z = float.Parse(gyro);
            }

        }

        if (mx != -1 & my != -1)
        {
            Rocket.instance.TargetRot.y = Mathf.Atan2(my, mx) * Mathf.Rad2Deg;
        }
       
    }




}
