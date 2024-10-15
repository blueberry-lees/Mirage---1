using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{

    float audioLength;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioLength = audioSource.clip.length;
        Invoke("DestroyPrefab", audioLength);
    }

    void DestroyPrefab()
    {
        Destroy(gameObject);
    }
}
