using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CamaraPosition : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector3 startPosition;
    public Vector3 middlePosition;
    public Vector3 centerPosition;
    Vector2 velocity;
    public float smoothTime = 0.5f;
    public float speed = 5;
    private bool moveToMiddle;
    private bool moveToCenter;

    public GameObject puerta;
    public CamaraController camaraController;
    public bool walls;
    private bool flag;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        moveToMiddle = false;
        moveToCenter = false;
        walls = true;
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveToMiddle)
        {
            MoveToMiddle();
        }

        if (moveToCenter)
        {
            MoveToCenter();
        }
        float distanceToStart = Vector2.Distance(transform.position, startPosition);

        if (distanceToStart < 0.1f && camaraController.isRotating)
        {
            player.position = new Vector3(player.position.x, 0, 10);
         //   Debug.Log(distanceToStart);
            camaraController.isRotating = false;
            transform.position = startPosition;
            moveToMiddle = true;
        }

        float distanceToMiddle = Vector2.Distance(transform.position, middlePosition);
        if (distanceToMiddle < 0.1f && moveToMiddle)
        {
            moveToMiddle = false;
            puerta.SetActive(true);
            transform.position = middlePosition;

            camaraController.isRotating = true;

        }

        if (distanceToMiddle < 0.1f && !walls)
        {
            walls = true;
            camaraController.isRotating = false;
            transform.position = middlePosition;
            moveToCenter = true;
        }



        float distanceToCenter = Vector2.Distance(transform.position, centerPosition);
        if (distanceToCenter < 0.1f && !flag)
        {
            flag = true;
            moveToCenter = false;
            transform.position = centerPosition;
            camaraController.isRotating = true;
        }
    }

    public void MoveToMiddle()
    {
        transform.position = Vector2.SmoothDamp(transform.position, middlePosition, ref velocity, smoothTime, speed);
    }

    public void MoveToCenter()
    {
        transform.position = Vector2.SmoothDamp(transform.position, centerPosition, ref velocity, smoothTime, speed);
    }


}
