using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HertzRateController : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown hertzDropdown;
    
    private List<Resolution> _allResolutions;
    private List<float> _allRates = new List<float>();
    
    private int currentResolutionIndex = 0;
    

    private void Start()
    {
        List<Resolution> _allResolutions = new List<Resolution>();
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            _allResolutions.Add(Screen.resolutions[i]);
        }
        hertzDropdown.ClearOptions();

        for (int i = 0; i < _allResolutions.Count; i++)
        {
            float tempRate = _allResolutions[i].refreshRateRatio.numerator /
                             _allResolutions[i].refreshRateRatio.denominator;
            if (!_allRates.Contains(tempRate))
                _allRates.Add(tempRate);
        }

        List<string> options = new List<string>();
        foreach (float hz in _allRates)
        {
            
            string resolutionOption = (int)hz + " Hz";
            options.Add(resolutionOption);
            if (hz == (Screen.currentResolution.refreshRateRatio.numerator / Screen.currentResolution.refreshRateRatio.denominator))
            {
                currentResolutionIndex = _allRates.IndexOf(hz);
            }
        }
        
        hertzDropdown.AddOptions(options);
        hertzDropdown.value = currentResolutionIndex;
        hertzDropdown.RefreshShownValue();
    }

    public void SetRefreshRate(int rateIndex)
    {
        float rate = _allRates[rateIndex];
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, Screen.fullScreenMode, (int)rate);
    }
}