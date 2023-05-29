using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public float rotateSpeed = 0.01f;
    public bool isRotating;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, -0.2f);
        isRotating = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotating)
        {
            transform.Rotate(Vector3.forward * -rotateSpeed);
        } 




    } 
}
