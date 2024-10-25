using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlatformManager : MonoBehaviour
{
    [Header("Platforms")]
    public GameObject pathblock1;
    public GameObject pathblock2;


    [Header("Input Puzzle")]
    public GameObject questionObjLeft;
    public GameObject questionObjRight;
    //public GameObject rightbox;
    //public GameObject leftbox;
    //public TMP_InputField playerInputLeft;
    //public TMP_InputField playerInputRight;
    public TextMeshProUGUI question;
    //string rightAns = "132";
    //string leftAns = "321";

    public GameObject player;

    public AnswerDialogueTab answerDialogueTab;

    private void Start()
    {
        pathblock1.GetComponent<MovingTrap>().enabled =false;
    }

    // Start is called before the first frame update
    //void Start()
    //{

    //    playerInputLeft.onValueChanged.AddListener(CheckAnswerLeft);
    //    playerInputRight.onValueChanged.AddListener(CheckAnswerRight);

    //}

    //Update is called once per frame
    //void Update()
    //{

    //    if (platform1free == true)
    //    {
    //        newPlatform1.SetActive(true);
    //        pathblock1.SetActive(false);
    //    }
    //    if (platform2free == true)
    //    {
    //        newPlatform2.SetActive(true);

    //        pathblock2.SetActive(false);
    //    }

    //}

    public void LeftPlatform()
    {

        pathblock1.GetComponent<MovingTrap>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;

    }

    public void RightPlatform()
    {
        pathblock2.GetComponent<MovingTrap>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;
    }

    //public void LeftQuestion()
    //{

    //    questionObj.SetActive(true);
    //    OpenLeftQuestion(leftAns);

    //}

    //public void CheckAnswerLeft(string answer)
    //{

    //    // Example: Clear the input or limit it to 3 digits


    //    if (answer.Equals(leftAns))
    //    {
    //        Destroy(leftbox);
    //        platform1free = true;
    //        Debug.Log("platform 1 free");
    //        player.GetComponent<PlayerMovement>().enabled = true;
    //        questionObjLeft.SetActive(false);
    //        playerInputLeft.text = "";
    //    }

    //}
    //public void CheckAnswerRight(string answer)
    //{
    //    if (answer.Equals(rightAns))
    //    {
    //        Destroy(rightbox);
    //        platform2free = true;
    //        Debug.Log("platform 2 free");
    //        player.GetComponent<PlayerMovement>().enabled = true;
    //        questionObjRight.SetActive(false);
    //        playerInputRight.text = "";
    //    }
    //}



    //TODO
    //public IEnumerator waitForPlayerToGo










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
