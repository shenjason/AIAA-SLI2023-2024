using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform FollowTarget = null;
    public float SideSensitivity = 1;
    public float ZoomSensitivity = 1;
    public float RotateSensitivity = 1;
    private Vector3 prevMousePos;
    private Vector3 currentMousePos;
    private Vector3 Prevpos;
    void Start()
    {
        prevMousePos = Input.mousePosition;
        Prevpos = transform.position;
    }

    void LateUpdate()
    {
        //Side to Side
        currentMousePos = Input.mousePosition;
        if (FollowTarget == null)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 Movement = currentMousePos - prevMousePos;
                transform.position -= (transform.up * Movement.y * SideSensitivity * Time.deltaTime) + (transform.right * Movement.x * SideSensitivity * Time.deltaTime);
            }
        }
        else
        {
            transform.position = FollowTarget.position;
        }

        
        //Zoom
        transform.position += transform.forward * Input.mouseScrollDelta.y * ZoomSensitivity * Time.deltaTime;
        //Rotate

        if (Input.GetMouseButton(1))
        {
            Vector3 Rotdelta = new Vector3(-RotateSensitivity * (currentMousePos - prevMousePos).y, RotateSensitivity * (currentMousePos - prevMousePos).x);
            transform.eulerAngles += Rotdelta;
        }

        if (transform.position.y <= 5.5f & FollowTarget == null)
        {
            transform.position = Prevpos;
        }

        prevMousePos = currentMousePos;
        Prevpos = transform.position;

    }
}
