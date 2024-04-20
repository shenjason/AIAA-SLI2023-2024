using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManeger : MonoBehaviour
{
    public static DataManeger Instance;
    [Header("Const")]

    public float Scale = 0.5f;

    [Header("Data")]
    public float Latitude = 0;
    public float Longitude = 0;
    public float LatitudeI = -1;
    public float LongitudeI = -1;
    public float Tempature = 0;
    public float Pressure = 0;
    public float Humidity = 0;
    public float Altitude = 0;
    public float AltitudeI = -1;
    public float t = 0;
    public float DX = 0;
    public float DY = 0;
    public float DA = 0;
    public float dt = 0;
    [HideInInspector] public float pDY = 0;
    [HideInInspector] public float pDX = 0;
    [HideInInspector] public float pDA = 0;
    [HideInInspector] public float pt = -1;


    private void Awake()
    {
        DataManeger.Instance = this;
        LatitudeI = -1;
        LongitudeI = -1;
        AltitudeI = -1;
    }

    private void Start()
    {
        Rocket.instance.SetTrailState(false);
    }


    public static void UpdateData(string Data)
    {
        string[] RealData = Data.Split(',');

        Vector3 localacceleration = Vector3.zero;

        Quaternion newRot = Quaternion.identity;
        


        foreach (string d in RealData)
        {
            string data = d.Substring(2);
            if (d.StartsWith("et")) {
                DataManeger.Instance.pt = DataManeger.Instance.t;
                DataManeger.Instance.t = float.Parse(data);
            }
            if (d.StartsWith("gx"))
            {
                newRot.x = float.Parse(data);
            }
            if (d.StartsWith("gy"))
            {
                newRot.y = float.Parse(data);
            }
            if (d.StartsWith("gz"))
            {
                newRot.z = float.Parse(data);
            }
            if (d.StartsWith("gw"))
            {
                newRot.w = float.Parse(data);
            }
            if (d.StartsWith("ax"))
            {
                localacceleration.x = float.Parse(data);
            }
            if (d.StartsWith("ay"))
            {
                localacceleration.y = float.Parse(data);
            }
            if (d.StartsWith("az"))
            {
                localacceleration.z = float.Parse(data);
            }
            if (d.StartsWith("tp"))
            {
                DataManeger.Instance.Tempature = float.Parse(data);
            }
            if (d.StartsWith("pr"))
            {
                DataManeger.Instance.Pressure = float.Parse(data);
            }
            if (d.StartsWith("hu"))
            {
                DataManeger.Instance.Humidity = float.Parse(data);
            }
            if (d.StartsWith("la"))
            {
                DataManeger.Instance.Latitude = float.Parse(data);
                if (DataManeger.Instance.LatitudeI == -1)
                {
                    DataManeger.Instance.LatitudeI = float.Parse(data);
                }
            }
            if (d.StartsWith("lo"))
            {
                DataManeger.Instance.Longitude = float.Parse(data);
                if (DataManeger.Instance.LongitudeI == -1)
                {
                    DataManeger.Instance.LongitudeI = float.Parse(data);
                }
            }
            if (d.StartsWith("al"))
            {
                DataManeger.Instance.Altitude = float.Parse(data) * 3.2808399f;
                if (DataManeger.Instance.AltitudeI == -1)
                {
                    DataManeger.Instance.AltitudeI = float.Parse(data) * 3.2808399f;
                }
            }
        }

        UIManeger UIM = UIManeger.Instance;
        DataManeger DM = Instance;

        newRot =  new Quaternion(Mathf.Sin(Mathf.PI/4), 0, 0, Mathf.Cos(Mathf.PI/4)) * newRot;
        newRot.z = -newRot.z;

        Rocket.instance.TargetRot = newRot;

        Vector3 globalAcceleration =  localacceleration * 3.2808398950131f;

        UIM.UpdateAccel(globalAcceleration);    
        Rocket.instance.SetTrailState((globalAcceleration.z > 20));
        UIM.UpdateTeapotDisplay(newRot.eulerAngles);
        
        UIM.UpdateAltitude(DM.Altitude-DM.AltitudeI);
        UIM.UpdateElapasedTime(DM.t);
        
        UIM.UpdateGPS(DM.Latitude, DM.Longitude);
        
        DM.pDX = DM.DX;
        DM.pDY = DM.DY;

        int mdx = -1;
        int mdy = -1;
        if (DM.Latitude > DM.LatitudeI)
        {
            mdx = 1;
        }
        if (DM.Longitude > DM.LongitudeI)
        {
            mdy = 1;
        }

        DM.DX = mdx * Distance(DM.LatitudeI, DM.LongitudeI, DM.Latitude, DM.LongitudeI);
        DM.DY = mdy * Distance(DM.LatitudeI, DM.LongitudeI, DM.LatitudeI, DM.Longitude);


        float dx = DM.DX - DM.pDX;
        float dy = DM.DY - DM.pDY;
        float dz = DM.DA - DM.pDA;
        DM.dt = DM.t - DM.pt;

        UIM.UpdateVel(new Vector3(dx/DM.dt, dy/DM.dt, dz/DM.dt));


        UIM.UpdateHumidity(DM.Humidity);
        UIM.UpdateTemp(DM.Tempature);
        UIM.UpdatePressure(DM.Pressure);
        UIM.UpdateDXDY(DM.DX, DM.DY);


        Rocket.instance.TargetPosition = new Vector3(DM.DX * DM.Scale, (DM.Altitude - DM.AltitudeI) * DM.Scale, DM.DY * DM.Scale);
    }


    public static float Distance(float lat1, float lon1, float lat2, float lon2)
    {
        float R = 2.093e7f;
        float lat1r = Mathf.Deg2Rad * lat1;
        float lat2r = Mathf.Deg2Rad * lat2;
        float dlat = (lat2 - lat1) * Mathf.Deg2Rad;
        float dlon = (lon2 - lon1) * Mathf.Deg2Rad;
        float a = Mathf.Pow(Mathf.Sin(dlat / 2), 2) + Mathf.Cos(lat1r) * Mathf.Cos(lat2r) * Mathf.Pow(Mathf.Sin(dlon / 2), 2);
        float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));


        return R * c;
    }

    public void ResetInitialState()
    {
        AltitudeI = Altitude;
        LatitudeI = Latitude;
        LongitudeI = Longitude;
        Rocket.instance.transform.position = Vector3.zero + Vector3.up * 7.621551f;
        Rocket.instance.ResetTrail();
        int mdx = -1;
        int mdy = -1;
        if (Latitude > LatitudeI)
        {
            mdy = 1;
        }
        if (Longitude > LongitudeI)
        {
            mdx = 1;
        }
        DY = mdy * Distance(LatitudeI, LongitudeI, Latitude, LongitudeI);
        DX = mdx * Distance(LatitudeI, LongitudeI, LatitudeI, Longitude);
    }
}
