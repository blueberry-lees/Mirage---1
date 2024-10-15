using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public PlayerMovement playermovement;
    public GameObject virtualCamera1;
    public GameObject virtualCamera2;
    public float waitingTime;


    // Start is called before the first frame update
     IEnumerator Start()
    {
        yield return new WaitForSeconds(waitingTime * 0.5f);
        virtualCamera1.SetActive(true);
        yield return new WaitForSeconds(waitingTime);

        virtualCamera2.SetActive(true);

        yield return new WaitForSeconds(waitingTime * 1.5f);

        virtualCamera1.SetActive(false);
        virtualCamera2.SetActive(false);
        yield return new WaitForSeconds(waitingTime);

        playermovement.enabled = true;

    }

}
