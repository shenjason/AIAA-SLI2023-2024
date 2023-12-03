using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkingSphere : MonoBehaviour
{
    public Camera cam;
    public float sizescaling = 0.01f;
    public float initialSize = 5f;
    public float ShowDistance = 60;
    private MeshRenderer meshren;

    private void Start()
    {
        meshren = GetComponent<MeshRenderer>();
    }

    void FixedUpdate()
    {
        float dis = Vector3.Distance(cam.transform.position, transform.position);
        if (dis > ShowDistance)
        {
            meshren.enabled = true;
            float scaler = initialSize + (dis- ShowDistance) * sizescaling;
            transform.localScale = new Vector3(scaler, scaler, scaler);
            return;
        }
        meshren.enabled = false;
    }
}
