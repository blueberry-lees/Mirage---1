using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMagicCircles : MonoBehaviour
{
    public Cola colaScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        colaScript.SmallMagicCircles();
    }
}
