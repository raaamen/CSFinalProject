using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using Pixelplacement;
using UnityEngine.SceneManagement;
using Cinemachine;


public class EventManager : Singleton<EventManager>
{
    public List<Conversation> dialogues;
    public AudioSource audioSrc;
    public Camera oculusCamera;
    public Camera surveyCamera;
    public bool gameStarted;
    //public float lookTime;
    //bool seekingMysteryMan;
    public List<AudioClip> scaryAudioClips;
    
    //create methods that will allow new events and create new entries into dictionary
    public Dictionary<string, UnityEvent> eventsDictionary;
    

    public void DialogueStart(int index){
        DialogueManager.Instance.StartDialogue(dialogues[index]);
        //index++;
        //UpdateStory(index);
    }
    //this is gonna be some horrible code but im kinda starting to run out of time
    //im also feeling insane and i want to get this DONE.
    //unity has driven me crazy


    public void Init(){
        if (eventsDictionary == null)
        {
            eventsDictionary = new Dictionary<string, UnityEvent>();   
        }
        
    }

    private void Awake() {
        Init();
        audioSrc = GetComponent<AudioSource>();
    }

    private void Start() {
        GameManager.Instance.SetupBeginningOfGame();
    }
    //allows unityevent to trigger a unityaction
    public static void StartListening(string eventName, UnityAction listener){
        UnityEvent thisEvent = null;
        if (Instance.eventsDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Instance.eventsDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening (string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (Instance.eventsDictionary.TryGetValue (eventName, out thisEvent))
        {
            thisEvent.RemoveListener (listener);
        }
    }

    //allows event to be triggered from any script
    public static void TriggerEvent (string eventName)
    {
        UnityEvent thisEvent = null;
        if (Instance.eventsDictionary.TryGetValue(eventName, out thisEvent))
        {
            
            thisEvent.Invoke();
            Debug.Log("Event triggered:" +thisEvent);
        }
    }


    //THIS ALSO SHOULD NOT FUNCTION. IF IT DOES, I DONT KNOW HOW OR WHY
    private void UpdateStory(int currentIndex){
        switch (currentIndex)
        {
            case 0:
                break;
            case 1:
                //StartCoroutine(SpawnTimer(30, manprefab, firstManSpawn));
                break;
        }
    }

    //spawns a prefab at a position after a certain amount of time has passed
    //going to be used for story elements
    public IEnumerator SpawnTimer(float time, GameObject prefab, Vector3 pos){
        yield return new WaitForSeconds(time);
        Instantiate(prefab, pos, Quaternion.identity);
    }
    public  void PlayScarySound(int index, float volume){
        audioSrc.PlayOneShot(scaryAudioClips[index], volume);
    }
    public static void PlayScarySound(AudioClip clip, float volume){
        Debug.Log("Playing sound: "+ clip.name);
        EventManager.Instance.audioSrc.PlayOneShot(clip, volume);
    }

    

    void StoryBeat1(){
        //phone rings - convo1
        DialogueManager.Instance.InitDialogue(DialogueManager.Instance.storyBeat1Dialogue[0]);
        //play scary noises in background
        
        //spawntimer
    }

    void StoryBeat2(){

    }
    

    

}
