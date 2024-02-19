using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManeger : MonoBehaviour
{
    public static DataManeger Instance;
    [Header("Const")]

    public float ZScale = 0.1f;
    public float XYScale = 0.5f;

    [Header("Data")]
    public float Latitude = 0;
    public float Longitude = 0;
    public float LatitudeI = -1;
    public float LongitudeI = -1;
    public float Tempature = 0;
    public float Pressure = 0;
    public float Humidity = 0;
    public float pt = -1;
    public float Altitude = 0;
    public float AltitudeI = -1;
    public float t = 0;
    public float DX = 0;
    public float DY = 0;


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
        


        foreach (string d in RealData)
        {
            string data = d.Substring(2);
            if (d.StartsWith("et")) {
                DataManeger.Instance.pt = DataManeger.Instance.t;
                DataManeger.Instance.t = float.Parse(data);
            }
            if (d.StartsWith("gx"))
            {
                Rocket.instance.TargetRot.x = float.Parse(data);
            }
            if (d.StartsWith("gy"))
            {
                Rocket.instance.TargetRot.z = float.Parse(data);
            }
            if (d.StartsWith("gz"))
            {
                Rocket.instance.TargetRot.y = float.Parse(data);
            }
            if (d.StartsWith("gw"))
            {
                Rocket.instance.TargetRot.w = float.Parse(data);
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
                DataManeger.Instance.Altitude = float.Parse(data);
                if (DataManeger.Instance.AltitudeI == -1)
                {
                    DataManeger.Instance.AltitudeI = float.Parse(data);
                }
            }
        }

        UIManeger UIM = UIManeger.Instance;
        DataManeger DM = DataManeger.Instance;

        Vector3 globalAcceleration = Quaternion.Inverse(Rocket.instance.TargetRot) * localacceleration;

        UIM.UpdateAccel(globalAcceleration);
        Rocket.instance.SetTrailState((globalAcceleration.z > 4));
        UIM.UpdateTeapotDisplay(Rocket.instance.TargetRot.eulerAngles);
        UIM.UpdateAltitude(DM.Altitude-DM.AltitudeI);
        UIM.UpdateElapasedTime(DM.t - DM.pt);
        UIM.UpdateGPS(DM.Latitude, DM.Longitude);
        DM.DX = Distance(DM.LatitudeI, DM.LongitudeI, DM.Latitude, DM.LongitudeI);
        DM.DY = Distance(DM.LatitudeI, DM.LongitudeI, DM.LatitudeI, DM.Longitude);
        UIM.UpdateHumidity(DM.Humidity);
        UIM.UpdateTemp(DM.Tempature);
        UIM.UpdatePressure(DM.Pressure);


        Rocket.instance.TargetPosition = new Vector3(DM.DX * DM.XYScale, (DM.Altitude - DM.AltitudeI) * DM.ZScale, DM.DY * DM.XYScale);
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
        pt = t;
    }
}
