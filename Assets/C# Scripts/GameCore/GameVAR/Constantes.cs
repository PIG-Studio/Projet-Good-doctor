using System.Numerics;
using Interfaces;

namespace GameCore
{
    /// <summary>
    /// Constantes du jeu, les variables utiles pour differents scripts qui NE CHANGERONT PAS durant l'execution
    /// </summary>
    public static class Constantes
    {
        /// <summary>
        /// Point de spawn du joueur
        /// </summary>
        public static readonly Vector2 SpawningPos = new Vector2(0, 0);

        /// <summary>
        /// Facteur de vitesse maximale du joueur
        /// </summary>
        public const float MaxSpeed = 0.15f;

        /// <summary>
        /// Facteur de vitesse de déplacement du joueur
        /// </summary>
        public const float MoveSpeed = 1f;

        /// <summary>
        /// Bureau initial
        /// </summary>
        public static readonly Desk StartingDesk = Desks.Desk_Base;
        
        /// <summary>
        /// Capacite de l'inventaire
        /// </summary>
        public const int Invetory_Size = 10;
        
        /// <summary>
        /// Capacite d'un slot de l'inventaire
        /// </summary>
        public const int Invetory_Slot_Size = 3;
        
        /// <summary>
        /// Largeur d'un slot de l'inventaire
        /// </summary>
        public const int Invetory_Slot_Width = 10;
        
        /// <summary>
        /// Position du 1er slot de l'inventaire
        /// </summary>
        public static readonly Vector2 Invetory_Slot_Pos = new Vector2(10f, 10f);
    }
}