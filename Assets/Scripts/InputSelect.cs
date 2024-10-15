using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class InputSelect : MonoBehaviour
{

    public TMP_InputField myInputField;
  

    void Start()
    {
        StartCoroutine(Whatever());   
     }

    IEnumerator Whatever()
    {
        yield return new WaitForSeconds (.5f); //wait for 1 sec
        Debug.Log("wtf");
        myInputField.Select(); // Select the input field
        myInputField.ActivateInputField(); //Makes sure the keyboard input is active
    }


}
