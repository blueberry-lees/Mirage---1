using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using Unity.VisualScripting;



public class ButtonSound : MonoBehaviour
{
    public OnSelect OnSelect;
    public Button startButton;  // Reference to the 'Start' button
    public Button quitButton;   // Reference to the 'Quit' button
    public AudioSource audioSource;  // Reference to an AudioSource component
    public AudioClip selectionClip;  // The audio clip to play on selection

    private GameObject previousSelectedObject = null;  // Track previously selected object

    void Update()
    {
        // Get the currently selected GameObject from the EventSystem
        GameObject currentSelectedObject = EventSystem.current.currentSelectedGameObject;

        // Only play the sound if the selected button has changed
        if (currentSelectedObject != previousSelectedObject)
        {
            // Check if the selected object is the 'startButton' or 'quitButton'
            if (currentSelectedObject == startButton.gameObject || currentSelectedObject == quitButton.gameObject)
            {
                PlaySelectionAudio();
            }

            // Update the previous selected object
            previousSelectedObject = currentSelectedObject;
        }
    }

    void PlaySelectionAudio()
    {
        // Play the audio clip if it’s not already playing
        if (audioSource && selectionClip)
        {
            //audioSource.pitch = Random.Range(0f, 1f);

            audioSource.PlayOneShot(selectionClip);  // Play the sound once
        }
    }
}


