using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PARAMHzRate : MonoBehaviour, IDropdownable
{
    [FormerlySerializedAs("_hertzDropdown")] [SerializeField] TMP_Dropdown hertzDropdown;
    
    private List<Resolution> _allResolutions;
    private List<float> _allRates = new List<float>();

    private int _currentResolutionIndex;
    
    public void Start()
    /*
     methode appele des que le bouton est rendu pour la 1e fois,
     on y verifie quels taux sont dispo, quelle que soit la resolution, et les affiche dans la liste.
     On peut donc choisir une combinaison taux/res pas encore cree mais pas impossible, donc on peut choisir librement le taux voulu.
     */
    {
        hertzDropdown.onValueChanged.AddListener(SetRefreshRate);
        _allResolutions = new List<Resolution>();
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            _allResolutions.Add(Screen.resolutions[i]);
        }
        hertzDropdown.ClearOptions();

        for (int i = 0; i < _allResolutions.Count; i++)
        {
            float tempRate = _allResolutions[i].refreshRateRatio.numerator /
                                     (float)_allResolutions[i].refreshRateRatio.denominator;
            if (!_allRates.Contains(tempRate))
                _allRates.Add(tempRate);
        }

        List<string> options = new List<string>();
        foreach (float hz in _allRates)
        {
            
            string resolutionOption = (int)hz + " Hz";
            options.Add(resolutionOption);
            if (hz == Screen.currentResolution.refreshRateRatio.numerator / 
                       Screen.currentResolution.refreshRateRatio.denominator)
            {
                _currentResolutionIndex = _allRates.IndexOf(hz);
            }
        }
        
        hertzDropdown.AddOptions(options);
        hertzDropdown.value = _currentResolutionIndex;
        hertzDropdown.RefreshShownValue();
    }

    public void SetRefreshRate(int rateIndex)
    {
        RefreshRate rate = new RefreshRate
        {
            numerator = (uint)_allRates[rateIndex],
            denominator = 1
        };
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, Screen.fullScreenMode, rate);
    }
    
    public void SetDropdown(TMP_Dropdown dropdown)
    {
        hertzDropdown = dropdown;
    }
}