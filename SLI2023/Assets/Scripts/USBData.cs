using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using TMPro;
using System;
using System.Diagnostics;
using UnityEngine.Events;
using System.Linq.Expressions;

public class USBData : MonoBehaviour
{
    public static SerialPort Port;
    public delegate void DataRecvEvent(string Data);
    public static event DataRecvEvent Event;
    public TMP_Dropdown PortnameDropDown;
    public TMP_Dropdown BaudRateDropDown;
    public string Data;
    public static USBData instance;

    private void Awake()
    {
        Port = new SerialPort();
        instance = this;
        Event += Rocket.UpdateData;
    }

    private void Update()
    {
 
        try
        { 
            if (!Port.IsOpen) return;
            if (Port.BytesToRead <= 0) return;
            Data = Port.ReadLine();
            Event(Data);
            //SendReply();
        }
        catch (Exception e)
        {
            Port.Close();
            Warning.Instance.ShowWarning("Device disconnected");
        }
    }

    public void SendReply()
    {
        Port.WriteLine("*");
    }

    public void OpenPort()
    {
        Port.PortName = PortnameDropDown.options[PortnameDropDown.value].text;
        Port.BaudRate = int.Parse(BaudRateDropDown.options[BaudRateDropDown.value].text);
        
        Port.Open();
        SendReply();
    }

    public void ClosePort()
    {
        Port.Close();
    }
   



}
