using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberLabeler : MonoBehaviour
{
    public GameObject Numberlabel;
    private float spacing = 30;
    private float increament = 300;
    // Start is called before the first frame update

    void Start()
    {
        increament = Mathf.Round(spacing * DataManeger.Instance.Scale);   

        for (int i = 1; i < 100; i++)
        {
            TextMesh mesh = Instantiate(Numberlabel, new Vector3(i * spacing, 4.5f, 0), Quaternion.identity, gameObject.transform).GetComponent<TextMesh>();
            mesh.transform.eulerAngles = new Vector3(90, 90, 0);
            mesh.text = (i*increament).ToString();
        }

        for (int i = 1; i < 100; i++)
        {
            TextMesh mesh = Instantiate(Numberlabel, new Vector3(0, 4.5f, i * spacing), Quaternion.identity, gameObject.transform).GetComponent<TextMesh>();
            mesh.transform.eulerAngles = new Vector3(90,  0, 0);
            mesh.text = (i * increament).ToString();
        }


        for (int i = 1; i < 100; i++)
        {
            TextMesh mesh = Instantiate(Numberlabel, new Vector3(-i * spacing, 4.5f, 0), Quaternion.identity, gameObject.transform).GetComponent<TextMesh>();
            mesh.transform.eulerAngles = new Vector3(90, -90, 0);
            mesh.text = (i * increament).ToString();
        }

        for (int i = 1; i < 100; i++)
        {
            TextMesh mesh = Instantiate(Numberlabel, new Vector3(0, 4.5f, -i * spacing), Quaternion.identity, gameObject.transform).GetComponent<TextMesh>();
            mesh.transform.eulerAngles = new Vector3(90, 180, 0);
            mesh.text = (i * increament).ToString();
        }
    }
}
