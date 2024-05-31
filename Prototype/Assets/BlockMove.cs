using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
