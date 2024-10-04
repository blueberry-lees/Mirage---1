using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cola2 : MonoBehaviour
{
    public int speed;
    float horizontal;
    float vertical;

    public GameObject key;


    Rigidbody2D rb;

    private void Start()
    {
        transform.position = Vector3.zero;
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
    
        if (collision.CompareTag("Key"))
        {
            Destroy(key.gameObject);
        }
    
    
    
    }




    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
       
        


        horizontal = Input.GetAxis("Horizontal")*speed;
        vertical = Input.GetAxis("Vertical")*speed;

    }

    private void FixedUpdate()
    {
         rb.velocity = new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
    }
}
