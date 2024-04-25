using JetBrains.Annotations;
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
}