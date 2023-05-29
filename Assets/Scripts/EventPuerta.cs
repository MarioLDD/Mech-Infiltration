using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EventPuerta : MonoBehaviour
{


    public GameObject puerta;
    // Start is called before the first frame update
    void Start()
    {
        puerta.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            puerta.SetActive(false);
        }
    }


}
