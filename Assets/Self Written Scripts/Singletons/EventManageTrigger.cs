using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManageTrigger : MonoBehaviour
{
    public UnityAction firstPhoneCall;
    public UnityAction secondPhoneCall;

    public UnityAction officeDoorClicked;


    [Header("Audio Clips")]
    public AudioClip phoneCall;

    private void OnEnable() {
        EventManager.StartListening("First Phone Call", firstPhoneCall);
        EventManager.StartListening("Second Phone Call", secondPhoneCall);
        EventManager.StartListening("Office Door Clicked", officeDoorClicked);
    }

    private void Awake() {
        firstPhoneCall = new UnityAction(FirstPhoneCall);
        secondPhoneCall = new UnityAction(SecondPhoneCall);
        officeDoorClicked = new UnityAction(OfficeDoorClicked);
    }

    public void FirstPhoneCall(){
        StartCoroutine("First_Phone_Call");
    }
    IEnumerator First_Phone_Call(){
        yield return new WaitForSeconds(10);
        EventManager.PlayScarySound(phoneCall, 1);
        yield return new WaitUntil(() => EventManager.Instance.audioSrc.isPlaying==false);
        //todo
        EventManager.Instance.DialogueStart(1);
    }
    public void SecondPhoneCall(){
        //todo
    }
    IEnumerator Second_Phone_Call(){
        //todo
        yield return null;
    }
    void OfficeDoorClicked(){
        //camera stuff
    }
    

}
