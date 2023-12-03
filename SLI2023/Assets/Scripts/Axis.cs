using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis : MonoBehaviour
{
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Rocket.instance.transform.position;
    }
}
