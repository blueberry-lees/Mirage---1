using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircle : MonoBehaviour
{
    public PlayerStats_3 stats;

    void OnTriggerStay2D(Collider2D collision)
    {

        Debug.Log("hit Magic circle");
        if(Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("NO");

            stats.MagicCircleRight();
        }

        if (Input.GetKeyDown(KeyCode.J) )
        {
            Debug.Log("JO");
            stats.MagicCircleLeft();
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exit");
    }

}
