using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public Transform cam;
    public Transform needle;

    // Update is called once per frame
    void Update()
    {
        needle.eulerAngles = new Vector3(0, 0, cam.eulerAngles.y);
    }
}
