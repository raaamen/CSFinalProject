using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioSettings : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider volumeSlider;

    public void OnVolumeChanged(){
        GameManager.Instance.audioSrc.volume = volumeSlider.value;
    }
}
