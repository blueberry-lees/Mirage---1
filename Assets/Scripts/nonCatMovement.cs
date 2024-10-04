using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nonCatMovement : MonoBehaviour
{
    Vector2 movement;
    //I chose to use Vector2 'name.x' instead of float 'horizontal'/'vertical' cus I find
    // it easier to read without getting confused with GetAxis "Horizontal"


    public float travelSpeed; //to control the movement speed
    
    public Animator animator; //to play left right animation


    // Start is called before the first frame update
    void Start()
    {
        movement.x = 0;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal")* travelSpeed;
        animator.SetFloat("Horizontal", movement.x);
    }

    private void FixedUpdate()
    {

        transform.position += new Vector3(movement.x, 0, 0) * Time.deltaTime;
        //placed this in FixedUpdate so when the player hits the wall they dont glitch
    }
}
