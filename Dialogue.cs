using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Dialogue 
{
    public string Name="???";
    public GameObject CharacterImage;
    public GameObject NextConversation;
    public GameObject ChooseBranch;
    public GameObject BackgroundImage;
    public int fontsize=36;
    [TextArea(3,10)]
    public string[] sentences;
}
