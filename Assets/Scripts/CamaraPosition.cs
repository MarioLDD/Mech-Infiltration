using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CamaraPosition : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 targetPosition;
    Vector2 velocity;
    public float smoothTime = 0.5f;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       

        transform.position = Vector2.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, speed);

    }

    public void MoveToMiddle()
    {
        //transform.position = Vector2.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, speed);
    }




}
