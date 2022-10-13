using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using UnityEngine.UI;

public class MenuManager : Singleton<MenuManager>
{
    public DisplayObject defaultButtons;
    public DisplayObject audioSettings;
    public DisplayObject videoSettings;
    // Start is called before the first frame update
    private void Awake() {
        defaultButtons.Solo();
    }
    public void OnStartButtonClick(){
        defaultButtons.HideAll();
        StartCoroutine(GameManager.Instance.StartGame());
    }
    public void OnAudioButtonClick(){
        audioSettings.Solo();
    }
    public void OnVideoButtonClick(){
        videoSettings.Solo();
    }
    public void OnBackButtonClick(){
        defaultButtons.Solo();
    }
}

