using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastLineRender : MonoBehaviour
{
    public Camera cam;
    public float scalefactor = 0.01f;
    public float initialscale = 0.8f;
    private TrailRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float width = initialscale + Vector3.Distance(cam.transform.position, transform.position) * scalefactor;
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
    }

    public void ClearLine()
    {
        lineRenderer.Clear();
    }
}
