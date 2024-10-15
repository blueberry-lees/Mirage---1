using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Rendering;
using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance; //so you can use this script anywhere in the game

    public Image characterIcon;
    public TextMeshProUGUI title;
    public TextMeshProUGUI line;

    public bool isDialogueActive = false;
    public float typingSpeed = 0.2f;
    public Animator animator;

    private Queue<DialogueLine> lines; //dont quite get it but it makes a queue for the dialogues

    private void Start()
    {
        if (instance == null)
        instance = this;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isDialogueActive = true;
        animator.Play("Show");
        lines.Clear();
        foreach (DialogueLine dialogueline in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueline);
        }
        DisplayNextDialogueLine();
    }

    public void DisplayNextDialogueLine()
    {
        if(lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = lines.Dequeue();

        characterIcon.sprite = currentLine.character.icon;
        title.text = currentLine.character.name;
        StopAllCoroutines();
        
        StartCoroutine(TypeSentence(currentLine));  
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        line.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
            {
            line.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        animator.Play("Hide");
    }
}
