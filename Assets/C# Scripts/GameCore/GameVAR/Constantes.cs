using System.Numerics;

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
        /// Capacite de l'inventaire
        /// </summary>
        public const int InventorySize = 10;
        
        /// <summary>
        /// Capacite d'un slot de l'inventaire
        /// </summary>
        public const int InventorySlotSize = 3;
        
        /// <summary>
        /// Largeur d'un slot de l'inventaire
        /// </summary>
        public const int InventorySlotWidth = 10;
        
        /// <summary>
        /// Position du 1er slot de l'inventaire
        /// </summary>
        public static readonly Vector2 InventorySlotPos = new Vector2(10f, 10f);
        
    }
}