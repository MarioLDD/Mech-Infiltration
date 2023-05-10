using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public float rotateSpeed =0.01f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * -rotateSpeed);




      //  rb.AddTorque(-rotateSpeed, ForceMode2D.Impulse);
       
        
       // if(rb.angularVelocity > 5)
        {
          //  rb.angularVelocity = -5;
        }
        
    }
}
