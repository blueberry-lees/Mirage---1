using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HPScript : MonoBehaviour
{
    public int heartAmount = 3;
    public GameObject[] hearts;

 

    [ContextMenu("Remove")]
    public void RemoveHeart()
    {
        heartAmount--;
        hearts[heartAmount].gameObject.SetActive(false);

        if (heartAmount == 0)
            Die();
    }

    public void Die()
    {
        Debug.Log("DEAD");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Respawn, etc.
    }
}
