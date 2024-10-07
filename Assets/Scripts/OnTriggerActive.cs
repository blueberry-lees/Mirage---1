using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnTriggerActive : MonoBehaviour
{

    [Header("On trigger")]
    [Tooltip("obj to turn ON on collision trigger")]
    public GameObject toSetActive;
    [Tooltip("obj to turn OFF on collision trigger")]
    public GameObject toSetActiveFalse;

    void OnTriggerEnter2D(Collider2D trigger)
    {


        toSetActive.gameObject.SetActive(true);
        toSetActiveFalse.gameObject.SetActive(false);

    }

}
