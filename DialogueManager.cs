using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text NameText;
    public Text DialogueText;
    public GameObject StartConversation;
    public GameObject NextConversation;
    public GameObject CharterImg;
    public GameObject BackgroundImg;
    private Queue<string> sentences;
    void Start()
    {
        sentences=new Queue<string>();
        if(StartConversation !=null){
            StartConversation.GetComponent<DialoguTrigger>().TriggerDialouge();
        }
    }

    // Update is called once per frame
   public void StartDialogue(Dialogue dialogue){
    if(dialogue.NextConversation != null){
        NextConversation=dialogue.NextConversation;    
    }else{NextConversation=null;}
    if(dialogue.CharacterImage !=null){
        CharterImg=dialogue.CharacterImage;
        CharterImg.SetActive(true);
    }
    if(dialogue.BackgroundImage !=null){
        BackgroundImg=dialogue.BackgroundImage;
        BackgroundImg.SetActive(true);
    }
    
    NameText.text=dialogue.Name;
    DialogueText.fontSize=dialogue.fontsize;
    sentences.Clear();

    foreach(string sentence in dialogue.sentences){
        sentences.Enqueue(sentence);
    }

    DisplayNextSentence();

   }

   public void DisplayNextSentence(){
    if(sentences.Count==0){
        EndDialogue();
        return;
    }
    string sentence=sentences.Dequeue();
    DialogueText.text=sentence;
    StopAllCoroutines();
    StartCoroutine(TypeSentence(sentence));
   }
   IEnumerator TypeSentence(string sentence){
    DialogueText.text="";
    foreach(char letter in sentence.ToCharArray()){
        DialogueText.text+=letter;
        yield return new WaitForSeconds(0.05f);
    }
   }
   public void EndDialogue(){
       if(CharterImg!=null){
        CharterImg.SetActive(false);
    }
    if(BackgroundImg!=null){
        BackgroundImg.SetActive(false);
    }
    if(NextConversation!=null){
        NextConversation.GetComponent<DialoguTrigger>().TriggerDialouge();
    }else{DialogueText.text="";}
 
   }
   
}
