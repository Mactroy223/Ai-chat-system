using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DialoguTrigger : MonoBehaviour
{
public Dialogue dialogue;
private Dialogue importDialogue; 

    
    private void Start(){
        if(GameObject.Find("Conversation")!=null&&this.name=="Conversation1"){importDialogue=GameObject.Find("Conversation").GetComponent<DialoguTrigger>().dialogue;
        dialogue.sentences=importDialogue.sentences;
        dialogue.Name=importDialogue.Name;
        
        dialogue.CharacterImage=importDialogue.CharacterImage;
        
       
        
        }
        
    }
    public void TriggerDialouge(){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
