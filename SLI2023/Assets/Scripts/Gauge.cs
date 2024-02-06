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
    public float minvalue = 0;
    public float maxvalue = 0;
    public string DisplayUnit;


    public void SetNeedle(float value)
    {
        GaugeDisplay.UpdateText(Mathf.RoundToInt(value).ToString() + DisplayUnit);

        Needle.eulerAngles = new Vector3(0, 0, -360 * (value / (maxvalue - minvalue)));
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
