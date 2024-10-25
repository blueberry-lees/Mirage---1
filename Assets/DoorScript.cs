using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    public GameObject sceneTrans;

    void OnTriggerEnter2D(Collider2D collision) //if collide with trigger
    {
        if (collision.CompareTag("Player")) //if it's key1
        {
            sceneTrans.GetComponent<SceneChanger>().sceneName = "The Coffin";
            Debug.Log("sceneNamechanged");
            sceneTrans.GetComponent<SceneChanger>().SceneChange();
        }
    }




}
