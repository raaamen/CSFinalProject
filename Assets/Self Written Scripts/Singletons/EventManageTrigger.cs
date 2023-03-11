using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManageTrigger : MonoBehaviour
{
    public UnityAction firstPhoneCall;

    [Header("Audio Clips")]
    public AudioClip phoneCall;

    private void Awake() {
        EventManager.StartListening("First Phone Call",firstPhoneCall);


        InitializeEvents();
    }

    void InitializeEvents(){
        firstPhoneCall+=FirstPhoneCall;
    }

    public void FirstPhoneCall(){
        Debug.Log("playing first phone call");
        EventManager.Instance.PlayScarySound(phoneCall, 1);
        
    }

    

}
