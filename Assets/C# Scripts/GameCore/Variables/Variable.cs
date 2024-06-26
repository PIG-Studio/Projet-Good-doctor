using System.Collections.Generic;
using Desks;
using Super.Interfaces.Destination;
using Super.Interfaces.GameObjects;
using UnityEngine;

namespace GameCore.Variables
{
    /// <summary>
    /// Les variables utiles pour differents scripts qui PEUVENT CHANGER durant l'execution
    /// </summary>
    public static class Variable
    {
        /// <summary>
        /// Le bureau actuel du joueur
        /// </summary>
        /// <returns>type: Desks</returns>
        public static Desk Desk { get; set; }

        /// <summary>
        /// Le nom de la partie en cours
        /// </summary>
        /// <returns>type: string</returns>
        public static string SaveName { get; set; }

        /// <summary>
        /// Le nom de la partie a changer ? UNSURE
        /// </summary>
        /// <returns>type: string</returns>
        public static string LoadName { get; set; }

        /// <summary>
        /// La derniere positon du joueur, actualisee lorsque le joueur sort de la map ou va dans le menu pause, utile pour sauvegarder la position 
        /// </summary>
        /// <returns>type: (float, float)</returns>
        public static (float, float) LatestPos { get; set; }

        /// <summary>
        /// nom de la scene active
        /// </summary>
        /// <returns>type: string</returns>
        public static string SceneNameCurrent { get; set; }

        /// <summary>
        /// nom de la derniere scene, utile pour ouvrir les param n'importe quand et revenir sur la scene precedente
        /// </summary>
        /// <returns>type: string</returns>
        public static string SceneNameLast { get; set; }
        
        
        ///////////////////// Variables des bureux, variables car nouvel objet si retoiur au menu //////////////////////
        /// <summary>
        /// 
        /// </summary>
        public static Desk DeskBase { get; set; }
        public static Desk Desk2 { get; set; }
        public static Desk Desk3 { get; set; }
        public static Desk Desk4 { get; set; }
        
        
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        public static Desk[] AllDesks { get; set; }

        private static uint _desksNb;

        public static uint DesksNb { get { _desksNb++; return _desksNb - 1; } }
    

        public static Desk CurrentlyRenderedDesk { get; set; }
        
        public static int ScoreJ1 { get; set; }

        public static int NbOfPatients;
        
        ///////////////////// Variables des destinations, variables car nouvel objet si retoiur au menu //////////////////////
        public static List<IDestination> AllDestinations { get; set; }
        public static INormalDestination[] NormalDestinations { get; set; }
        public static IDeskDestination[] DeskDestinations { get; set; }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static List<ICallOnSceneChange> ListToCallOnSceneChange { get; set; }

        public static int WaitTime { get; set; } = 0;
        
        public static RuntimeAnimatorController[] PnjSkin { get; } = new[]
        {
            Resources.Load<RuntimeAnimatorController>("Animations/Patient/jumeau/Player"), 
            Resources.Load<RuntimeAnimatorController>("Animations/Patient/rougeau/Player2"),
            Resources.Load<RuntimeAnimatorController>("Animations/Patient/violette/Anim")
        };
        
        public static Sprite[] AltSkin { get; } = new[]
        {
            Resources.Load<Sprite>("Animations/Patient/jumeau/DeskSprite"), 
            Resources.Load<Sprite>("Animations/Patient/rougeau/DeskSprite"),
            Resources.Load<Sprite>("Animations/Patient/violette/DeskSprite")
        };
        
        public static INormalDestination Sortie { get; set; }
        public static INormalDestination Cafet { get; set; }
    }
}