using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PARAMValues : MonoBehaviour
{
    public static string SavesPath { get; private set; } = Directory.GetCurrentDirectory() + "/Saves";
    public static string EscapeKey { get; private set; } = "escape";
    public static bool TextInput { get; private set; } = false;

}
