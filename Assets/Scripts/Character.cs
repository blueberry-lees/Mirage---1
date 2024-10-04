using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//add this to create the scriptable obj

[CreateAssetMenu(menuName = "Characters", fileName = "New Character")]

public class Character : ScriptableObject
{
      //what data do we need?

    public GameObject characterObj;
    public string characterName;// name
    public Sprite characterSprite;//image

    [TextArea]//extend text box in editor
    public string characterDescription;//description
}
