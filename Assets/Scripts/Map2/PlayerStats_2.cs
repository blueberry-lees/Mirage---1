using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using TMPro;

public class PlayerStats_2 : MonoBehaviour
{

    [Header("Items")]
    public GameObject codeItemZoom;
    public GameObject codeItem;
    bool getCodeItem = false;
    bool areYouSure = false;
    bool lol = false;

    [Header("Dialogue")]
    public TextMeshProUGUI dialogueText;
    public GameObject dialogue;
    public DialogueTab dialogueTab;



    [Header("Key")]
    public GameObject keyItem1;
    public GameObject keyItem2;
    bool allKeysCollected = false;
    bool key1Collected = false; //if key is collected
    bool key2Collected = false; //if key is collected



    private void Start()
    {
        
        key1Collected = false;
        
    }

    void OnTriggerEnter2D(Collider2D collision) //if collide with trigger
    {
        if (collision.CompareTag("Key1")) //if it's key1
        {
            FirstKeyCollected(collision.gameObject); 
        }
        if (collision.CompareTag("Key2")) //if it's key2
        {
            SecondKeyCollected(collision.gameObject); 
        }



        if (collision.gameObject == codeItem)
        {
            getCodeItem = true;
        }
    }

    public enum DialogueTab
    {
        take,
        are,
        lol
    }
    private void Update()
    {
        if (getCodeItem == true && areYouSure == false)
        {
            dialogue.SetActive(true);
            dialogueText.text = "Take this item?\r\n\r\n                                      Yes[Z]             No[X]";
            GetComponent<PlayerMovement>().enabled = false;

            if (Input.GetKeyDown(KeyCode.Z))//if yes
            {
                dialogue.SetActive(false);
                codeItemZoom.SetActive(true);
                codeItem.SetActive(false);
                GetComponent<PlayerMovement>().enabled = true;
                getCodeItem = false;

            }
            else if (Input.GetKeyDown(KeyCode.X))//if no
            {
                getCodeItem = false;
                areYouSure = true;
                lol = false;
            }
        }

        if (areYouSure == true && lol == false)
        {
            dialogueText.text = "Are you sure?\r\n\r\n                                      Yes[Z]             No[X]";
           
            if (Input.GetKeyDown(KeyCode.Z))//if yes
            {
                dialogue.SetActive(false);
                codeItem.SetActive(false);
                GetComponent<PlayerMovement>().enabled = true;
                getCodeItem = false;
            }

            else if (Input.GetKeyDown(KeyCode.X))//if no
            {
                lol = true;

            }
        }

        if(lol ==true)
        {
            dialogueText.text = "TOO LATE LOL BYE!!";
            codeItem.SetActive(false);
            GetComponent<PlayerMovement>().enabled = true;
            getCodeItem = false;
            Invoke("Lol", 2f);
        }



    }

    void Lol()
    {
        dialogue.SetActive(false);
    }

    public void FirstKeyCollected(GameObject key1)
    {
        key1Collected = true;  //key1 is collected (bollen = true)
        Destroy(key1.gameObject);
        Debug.Log("Key Collected!");
        keyItem1.gameObject.SetActive(true);

        if (key1Collected == true && key2Collected == true)
        {
            Debug.Log("got all keys");
            allKeysCollected = true;
        }
    }

    public void SecondKeyCollected(GameObject key2)
    {
        key2Collected = true;  //key2 is collected (bollen = true)
        Destroy(key2.gameObject);
        Debug.Log("Key Collected!");
        keyItem2.gameObject.SetActive(true);

        if (key1Collected == true && key2Collected == true)
        {
            Debug.Log("got all keys");
            allKeysCollected = true;
        }
    }


    public void UpdateText(string newText)
    {
        dialogueText.text = newText;
    }

}


