using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionsController : MonoBehaviour
{
    private Transform player;
    public float speed = 1;
    public float distanceDetection = 2;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, gameObject.transform.position);
        if( distanceFromPlayer < distanceDetection)
        transform.position = Vector2.MoveTowards(gameObject.transform.position, player.position, speed * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(gameObject.transform.position, distanceDetection);
    }
}
