using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Super.Interfaces;

namespace Parameters
{
    public class Resolutions : MonoBehaviour, IDropdownable
    {
        [SerializeField] public TMP_Dropdown dropdown;

        private Resolution[] _resolutions;
        private List<Resolution> _filteredResolutions;
        //private bool _manuel = false;
        private int _currentResolutionIndex;


        public void Start()
        {
            _resolutions = Screen.resolutions;
            _filteredResolutions = new List<Resolution>();

            dropdown.ClearOptions();


            for (int i = 0; i < _resolutions.Length; i++)
            {
                _filteredResolutions.Add(_resolutions[i]);
            }

            List<string> options = new List<string>();
            for (int i = 0; i < _filteredResolutions.Count; i++)
            {
                string resolutionOption = _filteredResolutions[i].width +
                                          "x" + _filteredResolutions[i].height;
                options.Add(resolutionOption);
                if (_filteredResolutions[i].width == Screen.currentResolution.width &&
                    _filteredResolutions[i].height == Screen.currentResolution.height)
                {
                    _currentResolutionIndex = i;
                    Debug.Log($"Set currentResolutionIndex to {_currentResolutionIndex}");
                }
            }

            dropdown.AddOptions(options);
            dropdown.value = _currentResolutionIndex;
            dropdown.RefreshShownValue();
            dropdown.onValueChanged.AddListener(SetResolution);
        }

        public void SetResolution(int resolutionIndex)
        {
            Resolution resolution = _filteredResolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode,
                Screen.currentResolution.refreshRateRatio);
        }

        public void SetDropdown(TMP_Dropdown inDropdown)
        {
            dropdown = inDropdown;
        }
    }
}