using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats_3 : MonoBehaviour
{

    [Header("Teleports")]

    public Transform rightPlateform;
    public Transform leftPlateform;
    public Transform spawnPoint;


    [Header("Items")]
    bool getCodeItem = false;
    public GameObject dialogue;
    public GameObject codeItemZoom;
    public GameObject codeItem;

    [Header("Key")]
    bool allKeysCollected;
    bool key1Collected; //if key is collected
    bool key2Collected; //if key is collected
    public GameObject keyItem1;


    private void Start()
    {

        key1Collected = false;

    }

    void OnTriggerEnter2D(Collider2D collision) //if collide with trigger
    {
        if (collision.CompareTag("Key")) //if it's key
        {
            key1Collected = true;  //key is collected (bollen = true)
            KeyCollected(collision.gameObject); //get function keycollected from logic script and execute it
        }

        if (collision.CompareTag("SmallMagicCircle")) //if it's small magic circle
        {
            transform.position = spawnPoint.position; //change position to zero
        }



        if (collision.gameObject == codeItem)
        {
            getCodeItem = true;
        }
    }

    private void Update()
    {
        if (getCodeItem == true)
        {
            dialogue.SetActive(true);
            GetComponent<Cola>().enabled = false;

            if (Input.GetKeyDown(KeyCode.Z))//if yes
            {
                dialogue.SetActive(false);
                codeItemZoom.SetActive(true);
                codeItem.SetActive(false);
                GetComponent<Cola>().enabled = true;
                getCodeItem = false;

            }
            else if (Input.GetKeyDown(KeyCode.X))//if no
            {
                dialogue.SetActive(false);
                GetComponent<Cola>().enabled = true;
                getCodeItem = false;

            }


        }

    }

    public void KeyCollected(GameObject key)
    {
        Destroy(key.gameObject);
        Debug.Log("Key Collected!");
        keyItem1.gameObject.SetActive(true);
    }




    //set 2 spawns

    public void MagicCircleRight()
    {
        transform.position = rightPlateform.position;
    }

    public void MagicCircleLeft()
    {
        transform.position = leftPlateform.position;
    }

    public void SmallMagicCircles()
    {
        transform.position = spawnPoint.position;
    }
}

