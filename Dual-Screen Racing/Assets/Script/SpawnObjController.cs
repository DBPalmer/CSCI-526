using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjController : MonoBehaviour
{
    public GameObject obstacleLeft;

    public GameObject obstacleRight;

    public GameObject prop1;

    public GameObject prop2;

    public bool isStopSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObj", 3, 2);
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

        GameObject cloneObstacleLeft = Instantiate(obstacleLeft, transform);

        GameObject cloneObstacleRight = Instantiate(obstacleRight, transform);

        GameObject cloneProp1 = Instantiate(prop1, transform);

        GameObject cloneProp2 = Instantiate(prop2, transform);
    }
}
