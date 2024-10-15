using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//can fetch the class from other script
public class DialogueCharacter
{
    public string name; 
    public Sprite icon;
}

[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(7,10)]        
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
    //here>>
    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogue);   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            TriggerDialogue();
        }
    }
}
