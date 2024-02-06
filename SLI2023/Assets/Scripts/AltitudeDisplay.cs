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
    public Slider maxslider;
    public TMP_Text ValueDisplay;
    public TMP_Text MaxValueDisplay;

    private float currentmaxvalue = 0;

    void Start()
    {
        slider.value = 0;
        maxslider.value = 0;
        currentmaxvalue = 0;
    }

    public void UpdateValue(float value)
    {
        slider.value = value / (maxvalue - minvalue);
        ValueDisplay.text =  Mathf.RoundToInt(value).ToString() + "ft";
        if (value > currentmaxvalue)
        {
            currentmaxvalue = value;
            UpdateMax(currentmaxvalue);
        }
    }

    public void UpdateMax(float value)
    {
        maxslider.value = value / (maxvalue - minvalue);
        MaxValueDisplay.text = Mathf.RoundToInt(value).ToString() + "ft";
    }
}
