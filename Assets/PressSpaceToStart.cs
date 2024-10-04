using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PressSpaceToStart : MonoBehaviour
{
    SceneChanger sceneChanger;
    

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
          sceneChanger.SceneChange();
        }
    }
}
