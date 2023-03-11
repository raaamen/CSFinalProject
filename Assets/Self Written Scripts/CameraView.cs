using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraView : MonoBehaviour
{
    public LayerMask cameraRenderLayerMask;
    private UnityAction manSeen;
    private bool isManSeen;
    public Camera mainCamera;
    //this goes on camera that outputs the render texture
    void Start()
    {
        manSeen+=ManSeen;
        manSeen+=Dialogue;

        EventManager.StartListening("ManSeen", manSeen);
        //StartCoroutine(SeekObject("MysteryMan"));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        
    }

    public IEnumerator SeekObject(string objectname){
        Debug.Log("coroutine started");
        var obj = GameObject.Find(objectname);
        bool objectFound = false;
        while (objectFound == false)
        {
            Debug.Log("seeking");
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, cameraRenderLayerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Hit "+hit.collider.gameObject.name);
                if (hit.collider.gameObject.name == "MysteryMan")
                {
                    Debug.Log("man was seen");
                    //EventManager.TriggerEvent("ManSeen");
                }
            }
            else Debug.Log("Didn't hit");
        }

        yield return null;
    }

    void ManSeen(){
        EventManager.Instance.PlayScarySound(0, 1);
    }
    void Dialogue(){
        //EventManager.Instance.InitDialogue();
    }



    //invote man seen event to eventmanager from here
}
