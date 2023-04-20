using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using UnityEngine.XR.Management;
using UnityEngine.XR;

public class XRControlManager : Singleton<XRControlManager>
{

    public GameObject OVRCAMERA;
    public GameObject FPSCAMERA;

    public GameObject OVRCANVAS;
    public GameObject FPSCANVAS;

    private void Awake() {
        if (XRSettings.isDeviceActive)
        {
            OVRCAMERA.SetActive(true);
            FPSCAMERA.SetActive(false);

            OVRCAMERA.gameObject.tag = "MainCamera";
            FPSCAMERA.gameObject.tag = "Untagged";

            OVRCANVAS.SetActive(true);
            FPSCANVAS.SetActive(false);
            Debug.Log("VR detected, initializing VR setup");
            //if vr is detected, initialize everything to do with that
            XRGeneralSettings.Instance.Manager.InitializeLoader();
            XRGeneralSettings.Instance.Manager.StartSubsystems();

            GameManager.Instance.firstPersonCamera = null;
            GameManager.Instance.gameIsInVR = true;
        }
        else {
            OVRCAMERA.SetActive(false);
            FPSCAMERA.SetActive(true);

            OVRCAMERA.gameObject.tag = "Untagged";
            FPSCAMERA.gameObject.tag = "MainCamera";

            OVRCANVAS.SetActive(false);
            OVRCANVAS.SetActive(true);
            Debug.Log("VR not detected, initializing FPS");
            //vr not detected, play keyboard and mouse
            XRGeneralSettings.Instance.Manager.StopSubsystems();
            XRGeneralSettings.Instance.Manager.DeinitializeLoader();

            GameManager.Instance.ovrCamera = null;
            GameManager.Instance.gameIsInVR = false;
        }
    }

    public void MainGameInitVR(){
        //cache maincamera to gamemanager instead of doing that shit here
        OVRCAMERA = GameObject.Find("OVRPlayerController");
        FPSCAMERA = GameObject.Find("FPSCamera");
        if (XRSettings.isDeviceActive)
        {

            OVRCAMERA.gameObject.tag = "MainCamera";
            FPSCAMERA.gameObject.tag = "Untagged";
            OVRCAMERA.SetActive(true);
            FPSCAMERA.SetActive(false);

            

            Debug.Log("VR detected, initializing VR setup");
            //if vr is detected, initialize everything to do with that
            XRGeneralSettings.Instance.Manager.InitializeLoader();
            XRGeneralSettings.Instance.Manager.StartSubsystems();

            GameManager.Instance.firstPersonCamera = null;
            GameManager.Instance.gameIsInVR = true;
        }
        else {

            OVRCAMERA.gameObject.tag = "Untagged";
            FPSCAMERA.gameObject.tag = "MainCamera";
            OVRCAMERA.SetActive(false);
            FPSCAMERA.SetActive(true);

            

            Debug.Log("VR not detected, initializing FPS");
            //vr not detected, play keyboard and mouse
            XRGeneralSettings.Instance.Manager.StopSubsystems();
            XRGeneralSettings.Instance.Manager.DeinitializeLoader();

            GameManager.Instance.ovrCamera = null;
            GameManager.Instance.gameIsInVR = false;

            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
