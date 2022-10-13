using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Pixelplacement;

public class GameManager : Singleton<GameManager>
{
    public DisplayObject PauseMenu;   
    public DisplayObject DialogueMenu;
    public DisplayObject OnScreenText;
    public DisplayObject LoadingScreen;
    public AudioSource audioSrc;
    public float gameStartBuffer;
    public bool gameLoading;
    public bool gameStart;
    public GameObject ovrCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        audioSrc = GetComponent<AudioSource>();
    }
    private void Update() {
        Debug.Log("test");
    }
    public void OnPause(){
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
    }
    public void OnUnpause(){
        PauseMenu.SetActive(false);
    }
    public IEnumerator StartGame(){
        Debug.Log("Loading main game scene");
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync("GameScene");
        Debug.Log("loading status: "+loadingOperation.isDone);
        gameStart=true;
        LoadingScreen.Solo();
        //this stuff doesnt run because the gamemanager unloads and then reloads
        yield return null;
    }
    

    public IEnumerator SetupBeginningOfGame(){
        gameLoading=true;
        Debug.Log("Loading done");
        Debug.Log("Game started");
        EventManager.Instance.gameStarted = true;
        StartCoroutine("SetupBeginningOfGame");
        DialogueMenu = GameObject.Find("DialoguePanel").GetComponent<DisplayObject>();
        OnScreenText = GameObject.Find("ScreenText").GetComponent<DisplayObject>();
        Debug.Log("Setting up beginning of game");
        ovrCamera = GameObject.Find("OVRCameraRig");
        yield return new WaitForSeconds(gameStartBuffer);
        EventManager.Instance.DialogueStart(0);
        gameLoading=false;
        yield return null;
    }

    
}
