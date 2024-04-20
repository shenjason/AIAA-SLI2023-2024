using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gauge : MonoBehaviour
{
    public TextDisplay X;
    public TextDisplay Y;
    public TextDisplay Z;
    public TextDisplay GaugeDisplay;
    public RectTransform Needle;
    public float startAngle = 0;
    public float endAngle = 360;
    public float minvalue = 0;
    public float maxvalue = 0;
    public string DisplayUnit;

    public void Start()
    {
        SetNeedle(0);
    }

    public void SetNeedle(float value)
    {
        GaugeDisplay.UpdateText(Mathf.RoundToInt(value).ToString() + DisplayUnit);

        float scale = Mathf.Clamp((value / (maxvalue - minvalue)), 0, 1);

        Needle.eulerAngles = new Vector3(0, 0, -(endAngle - startAngle) * scale - startAngle);
    }



    public void SetGauge(Vector3 value)
    {
        float mag = value.magnitude;
        SetNeedle(mag);
        X.UpdateText(Mathf.RoundToInt(value.x).ToString() + DisplayUnit);
        Y.UpdateText(Mathf.RoundToInt(value.y).ToString() + DisplayUnit);
        Z.UpdateText(Mathf.RoundToInt(value.z).ToString() + DisplayUnit);
    }
}
