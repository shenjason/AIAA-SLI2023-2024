using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using TMPro;
using System;

public class PortSelection : MonoBehaviour
{
    TMP_Dropdown dropdown;
    float prevTime;
    void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        UpdateDropDown();
    }

    private void Update()
    {
        if (Time.time - prevTime > 1)
        {
            UpdateDropDown();
            prevTime = Time.time;
        }

        try
        {
            if (USBData.Port.IsOpen)
            {
                dropdown.interactable = false;
            }
            else
            {
                dropdown.interactable = true;
            }
        } catch (Exception e)
        {
            dropdown.interactable = false;
        }
       
    }

    public void UpdateDropDown()
    {
        dropdown.ClearOptions();

        string[] Portnames = SerialPort.GetPortNames();
        if (Portnames.Length == 0)
        {
            List<TMP_Dropdown.OptionData> data = new List<TMP_Dropdown.OptionData>();
            data.Add(new TMP_Dropdown.OptionData("None"));
            dropdown.AddOptions(data);
        }
        else
        {
            List<TMP_Dropdown.OptionData> data = new List<TMP_Dropdown.OptionData>();
            foreach (string Portname in Portnames)
            {
                data.Add(new TMP_Dropdown.OptionData(Portname));
            }
            dropdown.AddOptions(data);
        }
    }
}
