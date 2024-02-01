using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PARAM_WindowMode: MonoBehaviour
{
    [SerializeField] private TMP_Dropdown windowModeDropdown;
    private List<FullScreenMode> _windowModes = new List<FullScreenMode>();
    private void Start()
    /*
     methode appele des que le bouton est rendu pour la 1e fois,
     on y verifie quelles options sont affichables selon l'OS
     */
    {
        _windowModes.Add(FullScreenMode.FullScreenWindow);
        _windowModes.Add(FullScreenMode.Windowed);
        
        windowModeDropdown.ClearOptions();
        List<string> options = new List<string>();
        options.Add("Borderless Windowed");
        options.Add("Windowed");

        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            _windowModes.Add(FullScreenMode.ExclusiveFullScreen);
            options.Add("Exclusive Full Screen");
        }
        
        windowModeDropdown.AddOptions(options);
        windowModeDropdown.value = _windowModes.IndexOf(Screen.fullScreenMode);
        windowModeDropdown.RefreshShownValue();
    }
    
    public void SetWindowMode(int WindowIndex)
    {
        Screen.SetResolution(Screen.width, Screen.height, _windowModes[WindowIndex], Screen.currentResolution.refreshRateRatio);
    }
}