using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;

public class PARAM_Resolutions : MonoBehaviour, IDropdownable
{
    [SerializeField] public TMP_Dropdown dropdown;

    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;
    private bool manuel = false;
    private int currentResolutionIndex = 0;
    

    public void Start()
    {
        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        dropdown.ClearOptions();
        

        for (int i = 0; i < resolutions.Length; i++)
        {
            filteredResolutions.Add(resolutions[i]);
        }

        List<string> options = new List<string>();
        for (int i = 0; i < filteredResolutions.Count; i++)
        {
            string resolutionOption = filteredResolutions[i].width +
                                      "x" + filteredResolutions[i].height;
            options.Add(resolutionOption);
            if (filteredResolutions[i].width == Screen.currentResolution.width  && filteredResolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
                Debug.Log($"Set currentResolutionIndex to {currentResolutionIndex}");
            }
        }
        
        dropdown.AddOptions(options);
        dropdown.value = currentResolutionIndex;
        dropdown.RefreshShownValue();
        dropdown.onValueChanged.AddListener(SetResolution);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = filteredResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode, Screen.currentResolution.refreshRateRatio);
    }
    
    public void SetDropdown(TMP_Dropdown inDropdown)
    {
        dropdown = inDropdown;
    }
}