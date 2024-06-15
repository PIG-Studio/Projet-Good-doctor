using System.Collections.Generic;
using UnityEngine;
using GameCore.Variables;
using Desks;
using Destinations.Lieux.Sortie;
using Super.Interfaces.Destination;

namespace GameCore.Methods
{
    /// <summary>
    /// Ce script DOIT etre dans l'objet du menu afin que les bureaux soient initialisés lorsau'on lance le jeu ou qu'on change de partie
    /// </summary>
    public class Desks : MonoBehaviour
    {
        
        public void Start()
        {
            Debug.unityLogger.logEnabled = Debug.isDebugBuild;
            Variable.AllDesks = new Desk[2];
            Variable.AllDestinations = new List<IDestination>();
            Variable.DeskDestinations = new IDeskDestination[] {null, null, null};
            Variable.NormalDestinations = new INormalDestination[] {null, null, null};
            Desk.SceneDeskDict = new Dictionary<string, Desk>();
            Variable.DeskBase = new Desk("DESK_Base");
            Variable.Desk2 = new Desk("DESK_2");
            Variable.Desk3= new Desk("DESK_3");
            Variable.Desk4 = new Desk("DESK_4");
            Variable.Sortie = Sortie.Dest_Sortie();

        }
    }
}