using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using static UnityEditor.Experimental.GraphView.GraphView;

public class InstructionPanel : MonoBehaviour
{
    Animator animator; //to play animation

    public GameObject[] turnOn; //things to appear on instruction panel
    public GameObject[] turnOff; //things not to appear on intruction panel
    public float time = 2f; //waiting time for the obj to set active

    // Start is called before the first frame update
    void Start()
    {
        //get animator on this game object
        animator = GetComponent<Animator>();

        //panel text that i want it to show up after a while after the scene starts
        StartCoroutine(ShowControls());

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            HideControls(); //didn't use IE bc I want this to be immediately turned off

            animator.Play("Hide"); //panel bg hide
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            animator.Play("Show"); //panel bg show

            //things that are in the scene that I want to be immediatly turned off when show the panel
            foreach (GameObject obj in turnOff)
            {
                obj.SetActive(false);
            }

            //panel text that i want it to show up after the animation
            StartCoroutine(ShowControls());
        }

    }


    void HideControls()
    {
        //go through the list in turnOn and set the game objs active true/false
        foreach (GameObject obj in turnOn)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in turnOff)
        {
            obj.SetActive(true);
        }

    }

    IEnumerator ShowControls()
    {
        //wait in seconds before running next line
        yield return new WaitForSeconds(time);

        //things on the panel
        foreach (GameObject obj in turnOn)
        {
            obj.SetActive(true);
        }

    }

    //                        <<<<<< test outs  >>>>>

    //void ShowControlls()
    //{

    //    foreach (GameObject obj in turnOn)
    //    {
    //        obj.SetActive(true);
    //    }
    //    foreach (GameObject obj in turnOff)
    //    {
    //        obj.SetActive(false);
    //    }

    //}


    //IEnumerator HideControls()
    //{
    //    yield return new WaitForSeconds(time);

    //    foreach (GameObject obj in turnOn)
    //    {
    //        obj.SetActive(false);
    //    }
    //    foreach (GameObject obj in turnOff)
    //    {
    //        obj.SetActive(true);
    //    }
    //}
}


