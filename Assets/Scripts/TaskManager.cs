using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TaskManager : MonoBehaviour
{

    public string menuScene;
    public GameObject sceneTrans;

    

    private void Start()
    {
        sceneTrans.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(menuScene);
    }

}


