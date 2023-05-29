using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public Transform transformCamera;

    // Start is called before the first frame update
    void Start()
    {
        transformCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = transformCamera.rotation;
    }
}
