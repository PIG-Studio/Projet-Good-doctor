using System;
using JetBrains.Annotations;
using Unity.Netcode;
using UnityEngine;
using static GameCore.Variables;

namespace GameCore
{
    /// <summary>
    /// Ce scipt DOIT etre dans l'objet du menu afin que les bureaux soient initialises lorsau'on lance le jeu ou qu'on change de partie
    /// </summary>
    public class Desks : MonoBehaviour
    {
        
        public void Start()
        {
            Desk.SceneDeskDict = new System.Collections.Generic.Dictionary<string, Desk>();
            Desk_Base = new Desk("DESK_Base");
            Desk_Upgraded = new Desk("DESK_Upgraded");
        }
    }
    
    public static class DesksConvert
    {
        [CanBeNull]
        public static Desk ToDesk(this string str)
        {
            return Desk.SceneDeskDict[str];
        }
        
        [NotNull]
        public static bool IsDesk(this string str)
        {
            try
            {
                if (str.ToDesk() != null)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}