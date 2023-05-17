using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbMinionsController : MonoBehaviour
{
    private Transform player;
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(gameObject.transform.position, player.position, speed * Time.deltaTime);
    }

}
