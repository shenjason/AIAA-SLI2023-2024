using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManeger : MonoBehaviour
{
    public static UIManeger Instance;
    public TextDisplay GPS;
    public TextDisplay ElapasedTime;
    public AltitudeDisplay Altitude;
    public Gauge Acceleration;
    public Gauge Velocity;
    public TextDisplay TeapotDisplayMag;
    public TextDisplay TeapotDisplay;
    public TextDisplay Pressure;
    public TextDisplay Temp;
    public TextDisplay Humidity;
    public TextDisplay DeltaX;
    public TextDisplay DeltaY;

    private void Awake()
    {
        Instance = this;
    }


    private void Start()
    {
        UpdateGPS(0, 0);
        UpdateTemp(0);
        UpdateVel(Vector3.zero);
        UpdateAccel(Vector3.zero);
        UpdateAltitude(0);
        UpdateHumidity(0);
        UpdatePressure(0);
        UpdateTeapotDisplay(Vector3.zero);
        UpdateAccel(Vector3.zero);
        UpdateElapasedTime(0);
        UpdateTeapotDisplayDir("N");
    }

    public void UpdateGPS(float lat, float lon)
    {
        GPS.UpdateText(lat.ToString() + "," + lon.ToString());
    }

    public void UpdateTemp(float temp)
    {
        Temp.UpdateText(Mathf.RoundToInt(temp).ToString() + "C");
    }
    public void UpdatePressure(float press)
    {
        Pressure.UpdateText(Mathf.RoundToInt(press).ToString() + "hpa");
    }

    public void UpdateHumidity(float humidity)
    {
        Humidity.UpdateText(Mathf.RoundToInt(humidity).ToString() + "%");
    }

    public void UpdateElapasedTime(float time)
    {
        ElapasedTime.UpdateText(time.ToString() + "s");
    }

    public void UpdateAltitude(float alt)
    {
        Altitude.UpdateValue(alt);
    }

    public void UpdateAccel(Vector3 accel)
    {
        Acceleration.SetGauge(accel);
    }

    public void UpdateVel(Vector3 vel)
    {
        Velocity.SetGauge(vel);
    }

    public void UpdateTeapotDisplayDir(string dir)
    {
        TeapotDisplayMag.UpdateText(dir);
    }

    public void UpdateTeapotDisplay(Vector3 Rot)
    {
        TeapotDisplay.UpdateText("X:" + Mathf.RoundToInt(Rot.x).ToString() + " Y:" + Mathf.RoundToInt(Rot.y).ToString() + " Z:" + Mathf.RoundToInt(Rot.z).ToString());
        float AbsRot = Rot.y - 22.5f;
        string dir = "SE";
        if (AbsRot > -22.5 && AbsRot < 22.5)
        {
            dir = "E";
        }else if (AbsRot > 22.5 && AbsRot < 67.5)
        {
            dir = "NE";
        }else if (AbsRot > 67.5 && AbsRot < 112.5)
        {
            dir = "N";
        }
        else if (AbsRot > 112.5 && AbsRot < 157.5)
        {
            dir = "NW";
        }
        else if (AbsRot > 157.5 && AbsRot < 202.5)
        {
            dir = "W";
        }
        else if (AbsRot > 202.5 && AbsRot < 247.5)
        {
            dir = "SW";
        }
        else if (AbsRot > 247.5 && AbsRot < 292.5)
        {
            dir = "S";
        }

        UpdateTeapotDisplayDir(dir);

    }

    public void UpdateDXDY(float dx, float dy)
    {
        DeltaX.UpdateText(Mathf.RoundToInt(dx).ToString() + "ft");
        DeltaY.UpdateText(Mathf.RoundToInt(dy).ToString() + "ft");
    }

}
