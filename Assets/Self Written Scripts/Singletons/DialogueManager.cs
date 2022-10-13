using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using Pixelplacement;
using UnityEngine.InputSystem;

public class DialogueManager : Singleton<DialogueManager>
{

    //before you roast me, i know everything is public
    //i wanted to test everything in inspector before making things private
    //also this is a singleton so some things need access
    //fully aware that this is bad i just dont have time to fix it
    public Queue<string> sentences;
    public GameObject textUIElements;
    public TextMeshProUGUI textBox;
    public TextMeshProUGUI nameBox;
    //public TextMeshProUGUI onScreenTextBox;
    //public Conversation conversationObj;
    public bool dialogueOccuring;
    public float textOffset;
    public AudioClip textSFX;
    public AudioSource audioSource;
    public string currentDialogueName;
    //for each character's "voice"
    //public Dictionary<string, AudioClip> charVoices;
    //public List<KeyValuePair> charVoicesList;
    void Awake() {
    sentences = new Queue<string>();
    //this is not functioning at the moment
    //charVoices = new Dictionary<string, AudioClip>();
     // foreach (KeyValuePair kvp in charVoicesList) {
      //  charVoices.Add(kvp.key, kvp.val);
     // }
      //PrintDictionary(charVoices);
    }
    //take in textasset from scriptableobject and turn it into queue
    public void StartDialogue(Conversation convoObj){
        //fill queue
        //go to first sentence
        //clearing again just to make sure
        Debug.Log("starting dialogue: "+convoObj.conversationName);
        currentDialogueName = convoObj.conversationName;
        sentences.Clear();
        ReadTextFile(convoObj.textFile);
        textUIElements.SetActive(true);
        WriteDialogue();
    }
    public void AdvanceDialogue(){
        sentences.Dequeue();
        if (sentences.Count==0)
        {
            EndDialogue();
        }
        else WriteDialogue();
    }
    public void WriteDialogue(){
        
        string currentSentence = sentences.Peek();
        if (currentSentence =="")
        {
            EndDialogue();
            return;
        }
        else if (currentSentence[0] == '$')
        {
            //set audio clip
            nameBox.text = currentSentence.Substring(1);
            //not functioning PrintDictionary(charVoices);
            //Debug.Log(charVoices.ContainsKey(nameBox.text));
            //audioSource.clip = charVoices[nameBox.text];
            sentences.Dequeue();
        }
        
        
        StartCoroutine(PrintOneByOne(sentences.Peek()));
    }
    public void EndDialogue(){
        //clear queue
        Debug.Log("dialogue ended");
        textUIElements.SetActive(false);
        sentences.Clear();
    }
    public void ReadTextFile(TextAsset asset){
        //read in from conversation
        Debug.Log("reading text file: "+asset.name);
        string content = asset.ToString();
        List<string> lines = content.Split('\n').ToList<string>();
        foreach (var item in lines)
        {
            sentences.Enqueue(item);
        }
        PrintQueue(sentences);
        Debug.Log(sentences.ToString());
    }
    private void OnMouseDown() {
        Debug.Log("mouse clicked");
        if (dialogueOccuring)
        {
            StopAllCoroutines();
            textBox.text = sentences.Peek();
        }
        else {
            AdvanceDialogue();
        }
    }
    public IEnumerator PrintOneByOne(string currentSentence){
        dialogueOccuring=true;
        Debug.Log("printing");
        Debug.Log("current sentence: "+currentSentence);
        string tempsentence = "";
        for (int i = 0; i < currentSentence.Length; i++)
        {
            tempsentence+=currentSentence[i].ToString();
            Debug.Log(tempsentence);
            textBox.text = tempsentence;
            //audioSource.Play();
            yield return new WaitForSeconds(textOffset);
        }
        dialogueOccuring=false;
        yield return new WaitForSeconds(1);
        AdvanceDialogue();
        yield return null;
    }

    public string ConvoNameOccuring(){
        if (dialogueOccuring == false)
        {
            return null;
        }
        
        return null;
    }

    public bool DialogueOccuring(){
        return dialogueOccuring;
    }

    //some stuff for debugging
    void PrintDictionary(Dictionary<string, AudioClip> dict){
        foreach (var item in dict)
        {
            Debug.Log("Key: "+item.Key+"\nValue: "+item.Value);
        }
    }
    void PrintQueue(Queue<string> queue){
        string[] temp = (string[])queue.ToArray();
        foreach (var item in temp)
        {
            Debug.Log(item);
        }
    }
}

