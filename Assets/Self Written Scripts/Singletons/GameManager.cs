using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Pixelplacement;
using UnityEngine.XR;
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
    public GameObject firstPersonCamera;

    public XRControlManager xrManager;

    public Camera mainCamera;

    public bool gameIsInVR;

    [Header("Camera Warp Positions")]
    public Transform apartmentLivingRoom;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        xrManager = GetComponent<XRControlManager>();
        audioSrc = GetComponent<AudioSource>();
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
        xrManager.MainGameInitVR();
        EventManager.Instance.gameStarted = true;
        DialogueMenu = DialogueManager.Instance.DialogueMenu;
        OnScreenText = DialogueManager.Instance.OnScreenText;
        Debug.Log("Setting up beginning of game");
        ovrCamera = GameObject.Find("OVRPlayerController");
        firstPersonCamera = GameObject.Find("FPSCamera");
        Debug.Log("game set");
        Cursor.lockState = CursorLockMode.Locked;
        EventManager.Instance.DialogueStart(0);
        gameLoading=false;
    }
    
}
