using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nonCatMovement : MonoBehaviour
{
    Vector2 movement;
    //I chose to use Vector2 'name.x' instead of float 'horizontal'/'vertical' cus I find
    // it easier to read without getting confused with GetAxis "Horizontal"

    public SceneChanger changer; //scene transition obj

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
        //movement and animation
        movement.x = Input.GetAxis("Horizontal")* travelSpeed;
        animator.SetFloat("Horizontal", movement.x);


        //exit to menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            changer.SceneChange();
        }
    }

    private void FixedUpdate()
    {
        //using movement in FixedUpdate so when the player hits the wall they dont glitch
        transform.position += new Vector3(movement.x, 0, 0) * Time.deltaTime;
    }
}
