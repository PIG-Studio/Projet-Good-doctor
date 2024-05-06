using Desks;
using Interfaces.Destination;

namespace GameCore.GameVAR
{
    /// <summary>
    /// Les variables utiles pour differents scripts qui PEUVENT CHANGER durant l'execution
    /// </summary>
    public static class Variables
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
        public static Desk DeskUpgraded { get; set; }
        
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>
        /// 
        /// </summary>
        public static Desk[] Desks { get; set; }
        
        public static Desk CurrentlyRenderedDesk { get; set; }
        
        public static int ScoreJ1 { get; set; }

        public static int NbOfPatients;
        
        ///////////////////// Variables des destinations, variables car nouvel objet si retoiur au menu //////////////////////
        public static IDestination[] AllDestinations { get; set; }
        public static INormalDestination[] NormalDestinations { get; set; }
        public static IDeskDestination[] DeskDestinations { get; set; }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}