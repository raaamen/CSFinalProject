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
    //before you roast me, i know everything is public
    //i wanted to test everything in inspector before making things private
    //also this is a singleton so some things need access
    //fully aware that this is bad i just dont have time to fix it
    public List<Conversation> dialogues;
    //public int dialogueIndex;
    //private bool _gameStarted;
    //public Renderer characterRenderer;
    //public GameObject manprefab;
    //public Vector3 firstManSpawn;
    //int storylineIndex;
    //public Camera mainCamera;
    //public Camera oculusCamera;
    public bool gameStarted;
    //public float lookTime;
    //bool seekingMysteryMan;
    
    public void DialogueStart(int index){
        DialogueManager.Instance.StartDialogue(dialogues[index]);
        //index++;
        //UpdateStory(index);
    }
    //this is gonna be some horrible code but im kinda starting to run out of time
    //im also feeling insane and i want to get this DONE.
    //unity has driven me crazy

    private void Awake() {
        
        
    }

    private void Start() {
        if (GameManager.Instance.gameStart)
        {
            gameStarted=GameManager.Instance.gameStart;
            DialogueStart(0);
        }
    }

    //THIS DOES NOT FUNCTION AT THE MOMENT. I'VE REMOVED STORY ELEMENTS.
    //IF IT FUNCTIONS, THAT'S NOT SUPPOSED TO HAPPEN LOL
    private void Update() {
        //need to make function in manager to check if dialogue is occuring
        
        
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
    IEnumerator SpawnTimer(float time, GameObject prefab, Vector3 pos){
        yield return new WaitForSeconds(time);
        Instantiate(prefab, pos, Quaternion.identity);
    }
}
