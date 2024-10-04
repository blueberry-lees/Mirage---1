using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircle : MonoBehaviour
{
    public Cola colaScript;

    void OnTriggerStay2D(Collider2D collision)
    {

        Debug.Log("hit Magic circle");
        if(Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("NO");

            colaScript.MagicCircleRight();
        }

        if (Input.GetKeyDown(KeyCode.J) )
        {
            Debug.Log("JO");
            colaScript.MagicCircleLeft();
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exit");
    }

}
