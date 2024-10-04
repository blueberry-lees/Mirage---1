using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic : MonoBehaviour
{
    GameObject key;
    GameObject cola;
    public GameObject keyItem;

    public bool keyCollected = false;

    public Cola colaScript;
    

    private void Start()
    {

    }
    private void Awake() //execute once before the application starts.
    {
        key = GameObject.FindGameObjectWithTag("Key");
        cola = GameObject.FindGameObjectWithTag("Cola");
        //keyItem = GameObject.FindGameObjectWithTag("KeyItem");
    }

   


    //private void Update()
   // {
   //   if (colaScript.keyCollected == true) 
   //     {
   //         Debug.Log("You now have a key!");
   //     }
  //  }



}
