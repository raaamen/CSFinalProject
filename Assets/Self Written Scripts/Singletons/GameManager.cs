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
        Debug.Log("testing destroyonload");
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
        LoadingScreen.Solo();
        while (!loadingOperation.isDone)
        {
            Debug.Log("loading");
            yield return null;
        }
        
    }
    public void SetupBeginningOfGame(){
        gameLoading=true;
        Debug.Log("Loading done");
        Debug.Log("Game started");
        EventManager.Instance.gameStarted = true;
        DialogueMenu = DialogueManager.Instance.DialogueMenu;
        OnScreenText = DialogueManager.Instance.OnScreenText;
        Debug.Log("Setting up beginning of game");
        //ovrCamera = GameObject.Find("OVRCameraRig");
        Debug.Log("game set");
        EventManager.Instance.DialogueStart(0);
        EventManager.TriggerEvent("First Phone Call");
        gameLoading=false;

    }



    

    
}
