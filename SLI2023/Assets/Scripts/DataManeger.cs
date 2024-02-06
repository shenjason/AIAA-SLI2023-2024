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
    public float lat = 0;
    public float lon = 0;
    public float lati = -1;
    public float loni = -1;
    public float pt = -1;
    public float Altitude = 0;
    public float t = 0;
    public float DX = 0;
    public float DY = 0;


    private void Awake()
    {
        DataManeger.Instance = this;
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
                if (DataManeger.Instance.pt == -1)
                {
                    DataManeger.Instance.pt = float.Parse(data);
                }
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
            if (d.StartsWith("la"))
            {
                DataManeger.Instance.lat = float.Parse(data);
                if (DataManeger.Instance.lati == -1)
                {
                    DataManeger.Instance.lati = float.Parse(data);
                }
            }
            if (d.StartsWith("lo"))
            {
                DataManeger.Instance.lon = float.Parse(data);
                if (DataManeger.Instance.loni == -1)
                {
                    DataManeger.Instance.loni = float.Parse(data);
                }
            }
            if (d.StartsWith("al"))
            {
                DataManeger.Instance.Altitude = float.Parse(data);
            }
        }

        UIManeger.Instance.UpdateAccel(Quaternion.Inverse(Rocket.instance.TargetRot) * localacceleration);
        UIManeger.Instance.UpdateTeapotDisplay(Rocket.instance.TargetRot.eulerAngles);
        UIManeger.Instance.UpdateAltitude(DataManeger.Instance.Altitude);
        UIManeger.Instance.UpdateElapasedTime(DataManeger.Instance.t);
        UIManeger.Instance.UpdateGPS(DataManeger.Instance.lat, DataManeger.Instance.lon);
        DataManeger.Instance.DX = Distance(DataManeger.Instance.lati, DataManeger.Instance.loni, DataManeger.Instance.lat, DataManeger.Instance.loni);
        DataManeger.Instance.DY = Distance(DataManeger.Instance.lati, DataManeger.Instance.loni, DataManeger.Instance.lati, DataManeger.Instance.lon);

        Rocket.instance.TargetPosition = new Vector3(DataManeger.Instance.DX* Instance.XYScale, DataManeger.Instance.Altitude * DataManeger.Instance.ZScale, DataManeger.Instance.DY * DataManeger.Instance.XYScale);

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
}
