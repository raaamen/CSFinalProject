using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    public UnityEvent dialogueTrigger;
    public void DialogueTriggered(){
        Debug.Log("dialogue triggered");
        dialogueTrigger.Invoke();
    }

    [ContextMenu("Trigger Dialogue")]
    void TriggerDialogue(){
        DialogueTriggered();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.D))
        {
            DialogueTriggered();
        }
    }
}
