using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlatformManager : MonoBehaviour
{
    [Header("Platforms")]
    public GameObject newPlatform1;
    public GameObject newPlatform2;
    public GameObject pathblock1;
    public GameObject pathblock2;
    public bool platform1free = false;
    public bool platform2free = false;


    [Header("Input Puzzle")]
    public GameObject questionObj;
    public GameObject rightbox;
    public GameObject leftbox;
    public TMP_InputField playerInput;
    public TextMeshProUGUI question;
    string rightAns = "132";
    string leftAns = "321";

    public GameObject player;

    public AnswerDialogueTab answerDialogueTab;



    // Start is called before the first frame update
    void Start()
    {

        playerInput.onValueChanged.AddListener(CheckAnswer);

    }

    // Update is called once per frame
    void Update()
    {
        if (platform1free)
        {
            newPlatform1.SetActive(true);
            pathblock1.SetActive(false);
        }
        if (platform2free)
        {
            newPlatform2.SetActive(true);

            pathblock2.SetActive(false);
        }

    }
    //public void LeftQuestion()
    //{
       
    //    questionObj.SetActive(true);
    //    OpenLeftQuestion(leftAns);

    //}

    public void CheckAnswer(string answer)
    {

        if (answer.Equals(leftAns))
        {
            Destroy(leftbox);
            platform1free = true;
            Debug.Log("platform 1 free");
            player.GetComponent<PlayerMovement>().enabled = true;
            questionObj.SetActive(false);

        }

        if(answer.Equals(rightAns))
        {
            Destroy(rightbox);
            platform2free = true;
            Debug.Log("platform 2 free");
            player.GetComponent<PlayerMovement>().enabled = true;
            questionObj.SetActive(false);
        }
   
    }

    //public void TurnOnQuestion()
    //{
    //    questionObj.SetActive(true);
    //}











    public enum AnswerDialogueTab
    {
        whatIsRight,
        rightCorrect,
        rightWrong,
        whatIsLeft,
        leftCorrect,
        leftWrong
    }
}
