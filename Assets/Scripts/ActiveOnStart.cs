using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveOnStart : MonoBehaviour
{
    public GameObject[] gameObjectsList;
   //brooke taught me how to list like this which is much shorter lol


    void Awake()
    {
        ActivateAllGameObjects();
    }




    void ActivateAllGameObjects()
    {
        // Loop through each GameObject in the list
        foreach (GameObject obj in gameObjectsList)
        {
           
                // Set the GameObject active
                obj.SetActive(true);
        }
    }

  
}
