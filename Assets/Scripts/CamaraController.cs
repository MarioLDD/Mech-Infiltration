using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public float rotateSpeed = 0.01f;
    
    private bool isRotating;
    
    // Start is called before the first frame update
    void Start()
    {        
        isRotating = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isRotating)
        {
            transform.Rotate(Vector3.forward * -rotateSpeed);
        } 
    } 
}
