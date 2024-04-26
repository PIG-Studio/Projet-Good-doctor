using System.Numerics;

namespace GameCore.GameVAR
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

        public static readonly string[] AdnArray = new[]
        {
            "ttcagttgtg", "aatgaatgga", "cgtgccaaat",
            "agacgtgccg", "ccgccgctcg", "attcgcactt",
            "tgctttcggt", "tttgccgtcg", "tttcacgcgt",
            "ttagttccgt", "tcggttcatt", "cccagttctt"
        };

        public static readonly string[] AnormalAdnArray =
        {
            "Its fine", "HELIKOPTER HELIKOPTER", "Your Mom + SKill issue + Ratio",
            "EPI-REGIONNED", "Super Idol", "Bing Chilin"
        };

        public static readonly string[] PhraseArray = new[]
        {
            "J'ai faim , t'aurai pas une madelaine ??", "Quoi de neuf docteur",
            "Je suis cancer mais je n'ai pas le cancer pour autant ! *rire*",
            "J'espère que je n'ai rien de grave", "Je suis venu ici pour avoir un arrêt maladie",
            "Pas mal vôtre secrétaire ;)"
        };

        public static readonly string[] NameArray = new[]
        {
            "Jean Martin", "Yonas Ali", "John Smith", "Maria Khan", "Anya Ivanova", "Celine Nguyen"
        };

        public const int MaxPatient = 10;
    }
}