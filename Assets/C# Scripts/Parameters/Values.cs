using System.IO;
using UnityEngine;

namespace Parameters
{


    public class Values : MonoBehaviour
    {
        public static string SavesPath { get; private set; } = Directory.GetCurrentDirectory() + "/Saves";
        public static string EscapeKey { get; private set; } = "escape";
        public static bool TextInput { get; private set; } = false;

    }
}