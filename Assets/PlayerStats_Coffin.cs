using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats_Coffin : MonoBehaviour
{
    public GameObject endScene;
    public GameObject toMenu;
    public SceneChanger sceneChanger;
    public GameObject coffin;

    public bool enterEnd = false;
    public bool exitEnd = false;


    void Update()
    {
        if (enterEnd == true)
        {
            endScene.SetActive(true);
            gameObject.GetComponent<PlayerMovement>().enabled = false;

        }

        if (enterEnd == true && exitEnd == true)
        {
            toMenu.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                sceneChanger.SceneChange();
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == coffin)
        {
            StartCoroutine(WaitEndScene() );
        }
    }

    public IEnumerator WaitEndScene()
    {
        enterEnd = true;
        yield return new WaitForSeconds(10f);

        exitEnd = true;

    }


}



