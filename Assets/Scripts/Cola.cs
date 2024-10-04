using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class Cola : MonoBehaviour
{

    public Vector3 rightPlateform;
    public Vector3 leftPlateform;
    public Transform spawnPoint;
  


    public bool keyCollected; //if key is collected

    public GameObject keyItem;

    public HPScript health;

    public Animator animator; //player animator component

    Rigidbody2D rb;

    public float speed; //speed of player movement

    public MovementDirection moveDirection;

    public Transform cliffCheckObj;
    public LayerMask layer;
    public float wallDistance;




    public enum MovementDirection
    {
        idle,
        up,
        down,
        left,
        right
    }


    private void Start()
    {
        transform.position = Vector3.zero; //spwan point
        keyCollected = false;

        StartCoroutine(Movement());
    }


    void OnTriggerEnter2D(Collider2D collision) //if collide with trigger
    {
        if (collision.CompareTag("SmallMagicCircle")) //if it's small magic circle
        {
            transform.position = Vector3.zero; //change position to zero
        }

        if (collision.CompareTag("Key")) //if it's key
        {
            KeyCollected(collision.gameObject); //get function keycollected from logic script and execute it
        }

        if (collision.CompareTag("Trap")) //if it's key
        {
            TakeDamage(collision.gameObject); //get function keycollected from logic script and execute it
        }

        //if (collision.CompareTag("Object")) //if it's key
        //{
        //    Collected(collision.gameObject); //get function keycollected from logic script and execute it
        //    //keyCollected = true;  //key is collected (bollen = true)
        //}

    }

    public void KeyCollected(GameObject key)
    {
        keyCollected = true;  //key is collected (bollen = true)
        Destroy(key.gameObject);
        Debug.Log("Key Collected!");
        keyItem.gameObject.SetActive(true);
    }

    public void Collected(GameObject obj)
    {
        Destroy(obj.gameObject);
        Debug.Log("Object Collected!");
        //keyItem.gameObject.SetActive(true);
    }

    public void TakeDamage(GameObject trap)
    {
        health.RemoveHeart();
        Debug.Log("damaged!");

        animator.SetTrigger("TakeDamage");
    }


    private void Awake() //execute once before the application starts.
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()// Update is called once per frame
    {
        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection = MovementDirection.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveDirection = MovementDirection.down;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveDirection = MovementDirection.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDirection = MovementDirection.right;
        }
        else
        {
            moveDirection = MovementDirection.idle;
        }

    }

    IEnumerator Movement()
    {
        bool isMoving = false;
        Vector2 startPosition = transform.position;
        Vector2 currentPosition = transform.position;
        Vector2 tilePosition = transform.position;

        float t = 0;

        while (true)
        {
            if (isMoving == false && moveDirection != MovementDirection.idle)
            {
                isMoving = true;
                Vector2 actualDirection = Vector2.zero;
                switch (moveDirection)
                {
                    case MovementDirection.up:
                        actualDirection = Vector2.up;
                        break;
                    case MovementDirection.down:
                        actualDirection = Vector2.down;
                        break;
                    case MovementDirection.left:
                        actualDirection = Vector2.left;
                        break;
                    case MovementDirection.right:
                        actualDirection = Vector2.right;
                        break;
                }


                //TODO
                //Send a raycast in the move direction  to make sure there is no wall
                //if there is a wall we need to ignore the below code
                if (!CheckCliff(actualDirection))
                {
                    animator.SetFloat("Horizontal", actualDirection.x);
                    animator.SetFloat("Vertical", actualDirection.y);

                    startPosition = transform.position; //start position
                    currentPosition = transform.position; //current Position
                    tilePosition = (Vector2)transform.position + actualDirection; //end position
                    t = 0;
                }
            }

            if (isMoving == true)
            {
                t += Time.deltaTime * speed;
                currentPosition = Vector2.Lerp(startPosition, tilePosition, t);
                if (t >= 1)
                {
                    currentPosition = tilePosition;
                    isMoving = false;
                }

                transform.position = currentPosition;
            }
            else
            {
                animator.SetFloat("Horizontal", 0);
                animator.SetFloat("Vertical", 0);
            }

            yield return null;
        }
    }

    public bool CheckCliff(Vector2 direction)
    {
        bool meetCliff = false;
        //TODO Send Raycast to check for cliff
        RaycastHit2D hit;
        hit = Physics2D.Raycast(cliffCheckObj.position, direction, wallDistance, layer) ;
        if(hit.collider != null)
        {
            meetCliff = true;
        }

        //Debug.Log("cliff found: " + meetCliff); //important
        Debug.Log($"cliff found: {meetCliff}"); //more important
        return meetCliff;
    }


    //set 2 spawns

    public void MagicCircleRight()
    {
        transform.position = rightPlateform;
    }

    public void MagicCircleLeft()
    {
        transform.position = leftPlateform;
    }

    public void SmallMagicCircles()
    {
        transform.position = spawnPoint.position;
    }

}