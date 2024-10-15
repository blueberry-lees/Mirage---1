using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using static UnityEditor.Experimental.GraphView.GraphView;

public class InstructionPanel : MonoBehaviour
{
    Animator animator;
    
    public GameObject[] turnOn;
    public GameObject[] turnOff;
    public float time = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();

        ShowControlls();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            HideControlls();
            StartCoroutine(Wait());
  
            animator.Play("Hide");

            
            

        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            animator.Play("Show");
            StartCoroutine(Wait() );
            ShowControlls();


        }

    }

    void ShowControlls()
    {

        foreach (GameObject obj in turnOn)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in turnOff)
        {
            obj.SetActive(false);
        }
    
    }

    void HideControlls()
    {
        

        foreach (GameObject obj in turnOn)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in turnOff)
        {
            obj.SetActive(true);
        }

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(time);
    }
}
