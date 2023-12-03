using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BaudRateSelection : MonoBehaviour
{
    private TMP_Dropdown dropdown;
    private void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();
    }
    private void Update()
    {
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
        }
        catch (Exception e)
        {
            dropdown.interactable = false;
        }
        
    }
}
