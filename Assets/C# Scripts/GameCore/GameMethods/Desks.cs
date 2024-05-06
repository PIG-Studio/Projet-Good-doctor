using UnityEngine;
using GameCore.Variables;
using Desks;
using Interfaces.Destination;

namespace GameCore.GameMethods
{
    /// <summary>
    /// Ce scipt DOIT etre dans l'objet du menu afin que les bureaux soient initialises lorsau'on lance le jeu ou qu'on change de partie
    /// </summary>
    public class Desks : MonoBehaviour
    {
        
        public void Start()
        {
            Variable.DeskDestinations = new IDeskDestination[] {null, null, null};
            Variable.NormalDestinations = new INormalDestination[] {};
            Desk.SceneDeskDict = new System.Collections.Generic.Dictionary<string, Desk>();
            Variable.DeskBase = new Desk("DESK_Base");
            Variable.DeskUpgraded = new Desk("DESK_Upgraded");
            
        }
    }
}