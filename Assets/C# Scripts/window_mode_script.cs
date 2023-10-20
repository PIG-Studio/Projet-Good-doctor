using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class window_Mode_Controller : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown windowModeDropdown;
    private List<FullScreenMode> _windowModes = new List<FullScreenMode>();
    private void Start()
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