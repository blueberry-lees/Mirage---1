using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PressSpaceToStart : MonoBehaviour
{
    public SceneChanger sceneChanger;
    

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
          sceneChanger.SceneChange();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
