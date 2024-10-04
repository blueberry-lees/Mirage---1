using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    public float trackSpeed = 10f;
    private Vector3 offset;
    private Vector3 camerPos;


    private void Start()
    {
        offset = transform.position - player.position;
    }

    private void Update()
    {

        camerPos = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, camerPos, trackSpeed * Time.deltaTime);
    }
}
