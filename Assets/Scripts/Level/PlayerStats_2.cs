using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using TMPro;
using System.Linq.Expressions;
using static PlayerStats_2;
using UnityEditor.Rendering;
using UnityEngine.EventSystems;

public class PlayerStats_2 : MonoBehaviour
{


    public PlatformManager platformManager;

    public GameObject questionObjLeft;
    public GameObject questionObjRight;
    public TMP_InputField playerInputLeft;
    public TMP_InputField playerInputRight;

    [Header("Items")]
    public GameObject codeItemZoom;
    public GameObject codeItem;
    bool getCodeItem = false;
    public GameObject code1zoom;
    public GameObject code2zoom;

    [Header("Dialogue")]
    public TextMeshProUGUI dialogueText;
    public GameObject dialogue;
    public DialogueTab dialogueTab;
    PlayerMovement playerMovement;



    [Header("Key")]
    public GameObject keyItem1;
    public GameObject keyItem2;
    public GameObject door;
    public GameObject sceneTrans;
    public bool allKeysCollected = false;
    bool key1Collected = false; //if key is collected
    bool key2Collected = false; //if key is collected





    private void Start()
    {
        dialogueTab = DialogueTab.take;
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        


    }


   
    /// <summary>
    /// CHEHCK COLLSION WITH: Key1, Key2, codeItem
    /// </summary>
    /// <param name="collision"></param>
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
        if(collision.gameObject == door)
        {
            sceneTrans.GetComponent<SceneChanger>().sceneName = "The Coffin";
            Debug.Log("sceneNamechanged");
            sceneTrans.GetComponent<SceneChanger>().SceneChange();
        }

        if (collision.CompareTag("Code1"))
        {
            playerMovement.StopMoving();
            code1zoom.SetActive(true);
        }
        if (collision.CompareTag("Code2"))
        {
            playerMovement.StopMoving();
            code2zoom.SetActive(true);
        }

        

        //left quesiton
        if (collision.CompareTag("LeftBox"))
        {
            playerMovement.StopMoving();
            questionObjLeft.SetActive(true);
        }

        //right quesiton

        if (collision.CompareTag("RightBox"))
        {
            playerMovement.StopMoving();
            questionObjRight.SetActive(true);
        }

    }

   



    private void Update()
    {
        //check if collide with codeItem and execute dialogue if true
        if(getCodeItem ==true)
        {
            SwitchDialogue();
        }

        //check if both keys are collected and show dialogue
        if(allKeysCollected ==true)
        {
            Debug.Log("GO TO THE DOOR");
            door.GetComponent<BoxCollider2D>().enabled =true;
            dialogueTab = DialogueTab.goDoor;
            SwitchDialogue();
            allKeysCollected = false;
        }

        //in case player needs to exit question
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(Exit());
        }
    }

    public IEnumerator Exit()
    {
        Debug.Log("exit");
        gameObject.GetComponent<PlayerMovement>().enabled = true;
        questionObjLeft.SetActive(false);
        questionObjRight.SetActive(false);
        code1zoom.SetActive(false);
        code2zoom.SetActive(false);

        yield return new WaitForSeconds(2f);
    }

   


    public enum DialogueTab
    {
        take,
        takeYes,
        takeNo,
        areYes,
        areNo,
        goDoor
    }



    /// <summary>
    /// This function checks the input in relation to the dialogueTabs
    /// </summary>
    public void SwitchDialogue() 

    {
        //check if codeItem dialogues are up
        if (dialogueTab == DialogueTab.take)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                dialogueTab = DialogueTab.takeYes;
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("pressed x");
                dialogueTab = DialogueTab.takeNo;
            }

        }
        else if (dialogueTab == DialogueTab.takeNo)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                dialogueTab = DialogueTab.areYes;
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                dialogueTab = DialogueTab.areNo;
            }
        }

        //check if door dialogue is up
        if (dialogueTab == DialogueTab.goDoor)
        {
            dialogue.SetActive(true);
            dialogueText.text = "Go to the door!";
            Invoke("Lol", 2f);
        }

        //dialogues and its executions
            switch (dialogueTab)
        {

            case DialogueTab.take:
                dialogue.SetActive(true);
                dialogueText.text = "Take this item?\r\n\r\n                                      Yes[Z]             No[X]";
                playerMovement.StopMoving();
                break;

            case DialogueTab.takeYes:
                codeItemZoom.SetActive(true);
                dialogue.SetActive(false);
                GetComponent<PlayerMovement>().enabled = true;
                getCodeItem = false;
                codeItem.SetActive(false);

                break;

            case DialogueTab.takeNo:
                dialogue.SetActive(true);
                dialogueText.text = "Are you sure?\r\n\r\n                                      Yes[Z]             No[X]";
                break;

            case DialogueTab.areYes:
                codeItemZoom.SetActive(false);
                dialogueText.text = "Fair enough, 'know-it-all'.";
                GetComponent<PlayerMovement>().enabled = true;
                getCodeItem = false;
                codeItem.SetActive(false);
                Invoke("Lol", 2f);

                break;


            case DialogueTab.areNo:
                dialogue.SetActive(true);
                dialogueText.text = "PFFFFF TOO LATE BYE!!";
                GetComponent<PlayerMovement>().enabled = true;
                getCodeItem = false;
                codeItem.SetActive(false);
                Invoke("Lol", 2f);
                break;
        }
    }



    /// <summary>
    /// This function sets dialogue textbox OFF
    /// </summary>
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





            // Unused method for dialogue
    //if (getCodeItem == true && areYouSure == false)
    //{
    //    dialogue.SetActive(true);
    //    dialogueText.text = "Take this item?\r\n\r\n                                      Yes[Z]             No[X]";
    //    GetComponent<PlayerMovement>().enabled = false;

    //    if (Input.GetKeyDown(KeyCode.Z))//if yes
    //    {
    //        dialogue.SetActive(false);
    //        codeItemZoom.SetActive(true);
    //        codeItem.SetActive(false);
    //        GetComponent<PlayerMovement>().enabled = true;
    //        getCodeItem = false;

    //    }
    //    else if (Input.GetKeyDown(KeyCode.X))//if no
    //    {
    //        getCodeItem = false;
    //        areYouSure = true;
    //        lol = false;
    //    }
    //}

    //if (areYouSure == true && lol == false)
    //{
    //    dialogueText.text = "Are you sure?\r\n\r\n                                      Yes[Z]             No[X]";

    //    if (Input.GetKeyDown(KeyCode.Z))//if yes
    //    {
    //        dialogue.SetActive(false);
    //        codeItem.SetActive(false);
    //        GetComponent<PlayerMovement>().enabled = true;
    //        getCodeItem = false;
    //    }

    //    else if (Input.GetKeyDown(KeyCode.X))//if no
    //    {
    //        lol = true;

    //    }
    //}

    //if(lol ==true)
    //{
    //    dialogueText.text = "TOO LATE LOL BYE!!";
    //    codeItem.SetActive(false);
    //    GetComponent<PlayerMovement>().enabled = true;
    //    getCodeItem = false;
    //    Invoke("Lol", 2f);
    //}

}


