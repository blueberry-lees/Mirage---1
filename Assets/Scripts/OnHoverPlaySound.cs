using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHoverPlaySound : MonoBehaviour
{

    public AudioManager audioManagerScript;
    public GameObject audioManager;

    private void Awake()
    {
        audioManagerScript = audioManager.GetComponent<AudioManager>();
    }

    void OnMouseEnter()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
        audioManagerScript.ButtonHoverSound();
    }


    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
        audioManagerScript.ButtonHoverExitSound();
    }
}

