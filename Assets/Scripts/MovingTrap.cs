using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class MovingTrap : MonoBehaviour
{

    public float speed;
    Transform currentPosition;

    public Transform positionOne;
    public Transform positionTwo;
    public Vector3 currentDirection;


    public float waitTimer;
    bool waiting;
    float waitCooldown;


    // Start is called before the first frame update
    void Start()
    {
        currentPosition = positionOne;

        positionOne.parent = null;
        positionTwo.parent = null;

    }

    // Update is called once per frame
    void Update()
    {
        MoveToPosition();
    }


    void MoveToPosition()
    {
        if (waiting == false)
        {
            currentDirection = (currentPosition.position - transform.position).normalized;
            transform.position += currentDirection * Time.deltaTime * speed;

            if (Vector2.Distance(transform.position, currentPosition.position) <= 0.1f)
            {
                waiting = true;
                waitCooldown = waitTimer;

            }
        }
        else
        {
            waitCooldown -= Time.deltaTime;

            if (waitCooldown <= 0)
            {
                waiting = false;
                SwitchDirection();
            }
        }

        void SwitchDirection()
        {
            if (currentPosition == positionOne)
            {
                currentPosition = positionTwo;
            }
            else
            {
                currentPosition = positionOne;
            }
        }
    }
}
