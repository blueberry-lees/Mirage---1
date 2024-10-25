using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;


public class LeftInput : MonoBehaviour
{
    public GameObject leftSwitch;
    public TMP_InputField myInputField;
    public string answer;
    public GameObject platformManager;
    PlatformManager platformManagerScript;

    void Start()
    {
        platformManagerScript = platformManager.GetComponent<PlatformManager>();
        myInputField.onValueChanged.AddListener(CheckAnswer);
        

    }

    public void CheckAnswer(string input)
    {

        if (input.Equals(answer))
        {
            myInputField.text = "";
            platformManagerScript.LeftPlatform();
            Destroy(leftSwitch);
            Destroy(gameObject);

        }
    }
}