using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PARAM_Values : MonoBehaviour
{
    public static string SavesPath { get; private set; } = ".";
    public static string EscapeKey { get; private set; } = "escape";
    public static bool TextInput { get; private set; } = false;

}
