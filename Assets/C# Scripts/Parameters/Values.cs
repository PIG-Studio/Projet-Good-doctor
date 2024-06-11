using System.IO;
using UnityEngine;

namespace Parameters
{
    public class Values : MonoBehaviour
    {
        /// <summary>
        /// pour sauvegarder des fichiers 
        /// </summary>
        public static string SavesPath { get; private set; } = Directory.GetCurrentDirectory() + "/Saves";
        public static string EscapeKey { get; private set; } = "escape";
        
        /// <summary>
        /// Booléen indiquant si la saisie de texte est activée ou désactivée
        /// </summary>
        public static bool TextInput { get; private set; } = false;

    }
}