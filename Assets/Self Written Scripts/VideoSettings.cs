using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using TMPro;

public class VideoSettings : MonoBehaviour
{
    public List<Resolution> resolutions;
    public bool currentlyFullscreen;
    public List<RenderPipelineAsset> graphicsSettingsList;
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown graphicsDropdown;
    public Toggle fullscreenToggle;

    private void OnEnable() {
        InitializeGraphics();
        InitializeResolutions();
    }

    public void OnResolutionChosen(){
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, currentlyFullscreen);
        Debug.Log("Resolution set to: "+Screen.currentResolution);
    }
    public void IsFullscreen(){
        Screen.fullScreen=fullscreenToggle.isOn;
        currentlyFullscreen = fullscreenToggle.isOn;
    }

    public void InitializeResolutions(){
        resolutionDropdown.ClearOptions();
        List<TMP_Dropdown.OptionData> data = new List<TMP_Dropdown.OptionData>();
        foreach (var item in resolutions)
        {
            TMP_Dropdown.OptionData newresolution = new TMP_Dropdown.OptionData();
            newresolution.text = item.name;
            data.Add(newresolution);
        }
        resolutionDropdown.AddOptions(data);
    }
    public void InitializeGraphics(){
        graphicsDropdown.ClearOptions();
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        foreach (var item in graphicsSettingsList)
        {
            TMP_Dropdown.OptionData data = new TMP_Dropdown.OptionData();
            data.text = item.name;
            options.Add(data);
        }
        graphicsDropdown.AddOptions(options);
    }
    public void OnGraphicsChanged(){
        QualitySettings.SetQualityLevel(graphicsDropdown.value);
        QualitySettings.renderPipeline = graphicsSettingsList[graphicsDropdown.value];
        Debug.Log("Graphics set to: "+QualitySettings.renderPipeline.name);
    }
}

