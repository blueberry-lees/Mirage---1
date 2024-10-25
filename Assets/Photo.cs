using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Photo : MonoBehaviour
{
    public GameObject photo;
    public GameObject player;
    // Start is called before the first frame update

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            player.GetComponent<PlayerMovement>().StopMoving(); 
            Debug.Log("hola");
            photo.SetActive(true);
            Destroy(gameObject);
        }
    }
}
