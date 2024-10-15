using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip buttonSelectionSound, buttonHoverExitSound, 
        buttonClickSound, keySound, damageSound;



    public void ButtonSelectionSound()
    {
        audioSource.clip = buttonSelectionSound;
        audioSource.Play();

    }
    public void ButtonCLickSound()
    {
        audioSource.clip = buttonClickSound;
        audioSource.Play();

    }
    public void KeySound()
    {
        audioSource.clip = keySound;
        audioSource.Play();
    }
    public void DamageSound()
    {
        audioSource.clip = damageSound;
        audioSource.Play();
    }
    public void ButtonHoverExitSound()
    {
        audioSource.clip = buttonHoverExitSound;
        audioSource.Play();
    }
}
