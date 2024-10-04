using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    //Learnt this from Brackeys


    public Animator transition;
    public float transitionTime = 1f;
    public string sceneName;

  
    public void SceneChange()
    {
        //run the IE

       StartCoroutine(LoadNextScene(sceneName));

    }


    public IEnumerator LoadNextScene(string sceneName)
    {
        //start animation trigger
        //wait for some time before  change into next scene
        //load scene "sceneName"

        transition.SetTrigger("StartTrans");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }
}
