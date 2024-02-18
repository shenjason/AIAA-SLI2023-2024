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
        TeapotDisplay.UpdateText("X:" + Rot.x.ToString() + " Y:" + Rot.y.ToString() + " Z:" + Rot.z.ToString());
    }



}
