using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

[System.Serializable]
public class InputSelect : MonoBehaviour
{

    public TMP_InputField myInputField;
    public string answer;
    public string method;
    public bool answerCorrect;
    public GameObject platformManager;


    void Start()
    {

        myInputField.onValueChanged.AddListener(CheckAnswer);

    }

    public void CheckAnswer(string input)
    {

        if (input.Equals(answer))
        {
            answerCorrect = true;

            myInputField.text = "";
            platformManager.SendMessage(method);

        }

    }



    //Destroy(leftbox);
    //platform1free = true;
    //Debug.Log("platform 1 free");
    //player.GetComponent<PlayerMovement>().enabled = true;
    //questionObjLeft.SetActive(false);
}
