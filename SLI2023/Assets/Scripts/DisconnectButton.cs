using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class DisconnectButton : MonoBehaviour
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
                button.interactable = false;
                return;
            }
            if (USBData.Port.IsOpen)
            {
                button.interactable = true;
                return;
            }
            button.interactable = false;
        }
        catch (Exception e)
        {
            button.interactable = false;
        }

    }
}
