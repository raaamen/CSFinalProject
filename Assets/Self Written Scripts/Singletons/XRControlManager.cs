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
        OVRCAMERA = GameObject.Find("CenterEyeAnchor");
        FPSCAMERA = GameObject.Find("MainCamera");
        if (XRSettings.isDeviceActive)
        {
           

            OVRCAMERA.SetActive(true);
            FPSCAMERA.SetActive(false);

            OVRCAMERA.gameObject.tag = "MainCamera";
            FPSCAMERA.gameObject.tag = "Untagged";

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

            Debug.Log("VR not detected, initializing FPS");
            //vr not detected, play keyboard and mouse
            XRGeneralSettings.Instance.Manager.StopSubsystems();
            XRGeneralSettings.Instance.Manager.DeinitializeLoader();

            GameManager.Instance.ovrCamera = null;
            GameManager.Instance.gameIsInVR = false;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
