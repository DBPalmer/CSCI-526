using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjController : MonoBehaviour
{
    public GameObject objLeft;
    public GameObject objRight;

    public GameObject prop1;

    public GameObject prop2;

    public bool isStopSpawn = false;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObj", 1, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObj()
    {
        // Randomly spawn objects

        if (isStopSpawn)
        {
            return;
        }

        GameObject clone = Instantiate(objLeft, transform);

        GameObject clone2 = Instantiate(objRight, transform);

        GameObject clone3 = Instantiate(prop1, transform);

        GameObject clone4 = Instantiate(prop2, transform);


    }
}
