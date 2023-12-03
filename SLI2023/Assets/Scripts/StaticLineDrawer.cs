using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticLineDrawer : MonoBehaviour
{
    LineRenderer lineRenderer;
    public Vector3[] positions;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = positions.Length;
        lineRenderer.SetPositions(positions);
    }

    
}
