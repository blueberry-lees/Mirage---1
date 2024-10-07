using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats_1 : MonoBehaviour
{

    bool allKeysCollected;

    bool key1Collected; //if key is collected
    bool key2Collected;

    public GameObject keyItem1; 
    public GameObject keyItem2;


    private void Start()
    {
        
        key1Collected = false;
        key2Collected = false;
    }

    void OnTriggerEnter2D(Collider2D collision) //if collide with trigger
    {
        if (collision.CompareTag("Key1")) //if it's key
        {
            key1Collected = true;  //key is collected (bollen = true)
            Key1Collected(collision.gameObject); //get function keycollected from logic script and execute it

        }
        if (collision.CompareTag("Key2")) //if it's key
        {
            key2Collected = true;  //key is collected (bollen = true)
            Key2Collected(collision.gameObject); //get function keycollected from logic script and execute it

        }
    }



        public void Key1Collected(GameObject key)
    {
        Destroy(key.gameObject);
        Debug.Log("Key-1 Collected!");
        keyItem1.gameObject.SetActive(true);
    }

    public void Key2Collected(GameObject key)
    {
        Destroy(key.gameObject);
        Debug.Log("Key-2 Collected!");
        keyItem2.gameObject.SetActive(true);
    }
}

