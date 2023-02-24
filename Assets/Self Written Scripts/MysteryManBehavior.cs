using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MysteryManBehavior : MonoBehaviour
{

    private UnityAction wasSeen;

    private void Awake() {
        wasSeen = new UnityAction(WasSeen);
    }
    

    private void OnEnable() {
        EventManager.StartListening("ManSeen", wasSeen);
    }
    private void OnDisable() {
        EventManager.StopListening("ManSeen", wasSeen);
    }

    private void WasSeen(){
        
    }

}
