using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using Unity.XR;


public class OculusInputSupport : MonoBehaviour
{
    public Chooser leftHandChooser;
    public Chooser rightHandChooser;
    void OnChooserSelect(){
        leftHandChooser.Pressed();
        rightHandChooser.Pressed();
    }
}
