using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AiToolbox;

public class CharacterManager : MonoBehaviour
{
    public CharacterDesign mycharacter;
    //private JsonData jsonData_myChar;
    public InputField inputName;
    public InputField inputDescription;
    public Dropdown age;
    public Dropdown personality;
    public Parameters parameters;
    public string prompt ;
    public GameObject myChar;

    public List<GameObject> charImg;
    private string myname;
    private string myage;
    private string mypersonality;
    private string myDescription;
    private string myRole;    
    public string[] dialogueArray;
      
    void Start()
    {  
       /* prompt= "Generate a galgame heroine self monologue.";
        Message singleMessage = new Message(prompt, Role.User);
        List<Message> messageList = new List<Message> { singleMessage };

       ChatGpt.QuickRequest(
            messageList,
            parameters,
            response => {
                Debug.Log("Response: " + response);
                response = response.Replace("\n", "");
                dialogueArray= response.Split('.');
                Debug.Log(dialogueArray);
            },
            (errorCode, errorMessage) => {
                var errorType = (ChatGptErrorCodes)errorCode;
                Debug.LogError("Error: " + errorType + " - " + errorMessage);
            }
        );*/
       
        
    }
   public void GenerateSentences(){
        prompt= "Generate a galgame heroine self monologue.Her name is "+myname+ ". She is a "+mypersonality+" "+myage+" "+myRole+" girl with the following background."+myDescription+"Regardless of language, use English punctuation for all punctuation when responding." ;
        Message singleMessage = new Message(prompt, Role.User);
        List<Message> messageList = new List<Message> { singleMessage };

       ChatGpt.QuickRequest(
            messageList,
            parameters,
            response => {
                Debug.Log("Response: " + response);
                response = response.Replace("\n", "");
                
                dialogueArray= response.Split('.');
                
                Debug.Log(dialogueArray);
                myChar.GetComponent<DialoguTrigger>().dialogue.sentences=dialogueArray;
            },
            (errorCode, errorMessage) => {
                var errorType = (ChatGptErrorCodes)errorCode;
                Debug.LogError("Error: " + errorType + " - " + errorMessage);
            }
        );

   }
    // Update is called once per frame
    void Update()
    {   myname=inputName.text;  
        myDescription=inputDescription.text;
        myage =age.captionText.text;
        mypersonality=personality.captionText.text;
        
        foreach (GameObject img in charImg)
        {
            
            bool isActive = img.activeSelf;
            if(isActive){
                myRole=img.name;
                
                myChar.GetComponent<DialoguTrigger>().dialogue.CharacterImage=img;
            }
            
        }
       
        //if(myname !=null&&age !=null&&Input.GetMouseButtonDown(1)){print(myname+" is a "+myage+ " person with a "+myRole+" Role");}
        
        myChar.GetComponent<DialoguTrigger>().dialogue.Name=myname;
       
    }
    
}
