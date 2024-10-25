using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RightInput : MonoBehaviour
{
    public GameObject rightSwitch;
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
            platformManagerScript.RightPlatform();
            Destroy(rightSwitch);
            Destroy(gameObject);

        }
    }
}
