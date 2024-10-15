using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//can fetch the class from other script
public class DialogueCharacter
{
    public string name; 
    public string description;
    public Sprite icon;
}

[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3,10)]        
    public string line;
}

[System.Serializable] 
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);   
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            TriggerDialogue();
        }
    }
}
