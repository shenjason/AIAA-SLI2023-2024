using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GaugeNumberSpawner : MonoBehaviour
{
    public Gauge copyGaugeStats;
    public GameObject NumberPrefab;
    public float spawnRadius = 1;
    public float startangle = 0;
    public float endangle = 360;
    public int splits = 5;
    public float minvalue = 0;
    public float maxvalue = 0;

    // Update is called once per frame
    void Start()
    {
        if (copyGaugeStats != null)
        {
            startangle = copyGaugeStats.startAngle; endangle = copyGaugeStats.endAngle;
            minvalue = copyGaugeStats.minvalue; maxvalue = copyGaugeStats.maxvalue;
        }


        for (int i = 0; i < splits; i++) {
            float cangle = -startangle + 90 - i*((endangle - startangle) / (splits - 1));
            TMP_Text texcomp = Instantiate(NumberPrefab, transform).GetComponent<TMP_Text>();
            texcomp.transform.position = transform.position + new Vector3(Mathf.Cos(cangle * Mathf.Deg2Rad) * spawnRadius, Mathf.Sin(cangle * Mathf.Deg2Rad) * spawnRadius, 0);
            int flip = 1;
            if (cangle < 0 && cangle > -180)
            {
                flip = -1;
            }
            texcomp.transform.eulerAngles = new Vector3 (0, 0, cangle - 90*flip);
            texcomp.text = Mathf.RoundToInt((((maxvalue - minvalue) / (splits - 1)) * i)).ToString();
        }
    }
}
