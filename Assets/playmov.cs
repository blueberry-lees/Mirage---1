using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playmov : MonoBehaviour
{
    Vector2 movement;
    public float speed;
    Rigidbody2D rb;



    // Start is called before the first frame update
    void Start()
    {
        rb  = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rb.velocity = movement* speed* 100f* Time.deltaTime;
    }
}
