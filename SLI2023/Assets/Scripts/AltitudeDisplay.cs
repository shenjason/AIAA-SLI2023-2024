using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class AltitudeDisplay : MonoBehaviour
{
    public float maxvalue = 6000f;
    public float minvalue = 0f;
    public Slider slider;
    public TMP_Text ValueDisplay;

    void Start()
    {
        slider.value = 0;
        UpdateValue(1000f);
    }

    public void UpdateValue(float value)
    {
        slider.value = value / (maxvalue - minvalue);
        ValueDisplay.text =  Mathf.RoundToInt(value).ToString() + "ft";
    }
}
