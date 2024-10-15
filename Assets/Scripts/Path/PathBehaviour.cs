using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PathBehaviour : MonoBehaviour
{

    //to change the color
    SpriteRenderer rend;
    public Color newColor;
    public Color oldColor;

    //check if collision happened
    bool pathAvailable = false;

    //to change the scene (same thing as sceneName in SceneChanger Script)
    SceneChanger sceneChanger;
    public string mapName;

    //to play transition animation
    
    public GameObject sceneTrans;
    public GameObject sFX3;
    public GameObject sFX8;



    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.color = oldColor;
        sceneChanger = sceneTrans.GetComponent<SceneChanger>();
    }


    private void Update()
    {
        // Check if W is pressed while the path is colliding with player
        if (pathAvailable && Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {

            SelectPath();
            Instantiate(sFX3);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("nonCat"))
        {
            ShowPath();
            pathAvailable = true;
            Instantiate(sFX8);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("nonCat"))
        {
            HidePath();
            pathAvailable = false; 
        }
    }

    void ShowPath()
    {
        rend.color = newColor;
    }

    void HidePath()
    {
        rend.color = oldColor;
    }




    void SelectPath()
    {
        sceneChanger.sceneName = mapName;
        sceneChanger.SceneChange();
    }

}
