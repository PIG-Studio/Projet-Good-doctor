using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public interface IDropdownable
{
    void Start();

    void SetDropdown(TMP_Dropdown dropdown);
}