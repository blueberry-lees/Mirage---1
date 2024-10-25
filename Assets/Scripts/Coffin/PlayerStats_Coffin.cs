using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats_Coffin : MonoBehaviour
{
    public GameObject endScene;
    public GameObject toMenu;
    public SceneChanger sceneChanger;
    public GameObject coffin;
    public GameObject photo;

    public bool enterEnd = false;
    public bool exitEnd = false;


    void Update()
    {
        
        if (enterEnd == true)
        {
            endScene.SetActive(true);
            gameObject.GetComponent<PlayerMovement>().StopMoving();
            

        }

        if (enterEnd == true && exitEnd == true)
        {
            toMenu.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                sceneChanger.SceneChange();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            photo.SetActive(false);
            gameObject.GetComponent<PlayerMovement>().enabled = true;
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



