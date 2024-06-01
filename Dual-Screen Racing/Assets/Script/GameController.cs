using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarController : MonoBehaviour
{

    public Transform zoom1;
    public Transform zoom2;

    // Start is called before the first frame update
    void Start()
    {
        Zoom2Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Zoom1Stop()
    {
        zoom1.GetComponent<SpawnObjController>().isStopSpawn = true;
        zoom2.GetComponent<SpawnObjController>().isStopSpawn = false;
        foreach (Transform t in zoom1)
        {
            t.GetComponent<ObjMove>().speed = 0;
        }

        foreach (Transform t in zoom2)
        {
            t.GetComponent<ObjMove>().speed = 100;
        }

    }


    public void Zoom2Stop()
    {
        zoom1.GetComponent<SpawnObjController>().isStopSpawn = false;
        zoom2.GetComponent<SpawnObjController>().isStopSpawn = true;

        foreach (Transform t in zoom1)
        {
            t.GetComponent<ObjMove>().speed = 100;
        }

        foreach (Transform t in zoom2)
        {
            t.GetComponent<ObjMove>().speed = 0;
        }

    }
}
