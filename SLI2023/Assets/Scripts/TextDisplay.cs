using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextDisplay : MonoBehaviour
{
    // Start is called before the first frame update

    TMP_Text textDis;
    
    void Awake()
    {
        textDis = GetComponent<TMP_Text>();
    }

    public void UpdateText(string text)
    {
        textDis.text = text;
    }
    
}
