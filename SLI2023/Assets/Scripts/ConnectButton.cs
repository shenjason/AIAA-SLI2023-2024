using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ConnectButton : MonoBehaviour
{
    public TMP_Dropdown PortNameDropDown;
    Button button;
    void Start()
    {
        button = GetComponent<Button>();
    }
    void Update()
    {
        try
        {
            if (PortNameDropDown.options[PortNameDropDown.value].text == "None")
            {
                button.interactable = false;
                return;
            }
            if (USBData.Port == null)
            {
                button.interactable = true;
                return;
            }
            if (USBData.Port.IsOpen)
            {
                button.interactable = false;
                return;
            }
            button.interactable = true;
        }
        catch (Exception e)
        {
            button.interactable = false;
        }
    }
}
