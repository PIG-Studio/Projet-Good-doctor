using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace GameCore.Constantes
{
    /// <summary>
    /// Constantes du jeu, les variables utiles pour differents scripts qui NE CHANGERONT PAS durant l'execution
    /// </summary>
    public static class Constante
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

        /// <summary>
        /// Tableau contenant des séquences d'ADN
        /// </summary>
        public static readonly string[] AdnArray = new[]
        {
            "ttcagttgtg", "aatgaatgga", "cgtgccaaat",
            "agacgtgccg", "ccgccgctcg", "attcgcactt",
            "tgctttcggt", "tttgccgtcg", "tttcacgcgt",
            "ttagttccgt", "tcggttcatt", "cccagttctt"
        };

        
        /// <summary>
        /// Tableau contenant des séquences d'ADN anormales
        /// </summary>
        public static readonly string[] AnormalAdnArray =
        {
            "Its fine", "HELIKOPTER HELIKOPTER", "Your Mom + SKill issue + Ratio",
            "EPI-REGIONNED", "Super Idol", "Bing Chilin" , "Bonjour je suis l'adn et je suis anormal"
            , "Va t'occuper du patient et arrête de lire" , "THE ONE PIECE IS REAL" , "Benoît Poelvoorde",
            "En vrai c'est bien les films Asterix"
        };
        /// <summary>
        /// Tableau contenant des phrases
        /// </summary>
        public static readonly string[] PhraseArray = new[]
        {
            "J'ai faim , t'aurai pas une madelaine ?", "Quoi de neuf docteur ?",
            "Je suis cancer mais je n'ai pas le cancer pour autant ! *rire*",
            "J'espère que je n'ai rien de grave", "Je suis venu ici pour avoir un arrêt maladie",
            "Pas mal vôtre secrétaire ;)" , "Quel est le comble pour un couturier ? Et bien d'être bouche cousue !",
            "Vous n'allez pas m'avoir avec vos vaccins à la 5G fournit par Microsoft",
            "J'ai vraiment des grosses douleurs à la tête , j'espère être soigné vite ",
            "Je me sens vraiment pas bien" , "Après le diagnostic je files voir mon match , ALLEZ L'OL",
            "Vous saviez que la plus courte guerre au monde n'a durée que 38 minutes ?"
        };
        /// <summary>
        /// Tableau contenant des noms
        /// </summary>
        public static readonly string[] NameArray = new[]
        {
            "Jean Martin", "Yonas Ali", "John Smith", "Maria Khan", "Anya Ivanova", "Celine Nguyen" ,
            "Andrew Bloom" , "Emile Leblanc" , "Grace Kone" , "Valentina Gonzalez" , "Rafi Asham" , "Aleksandr Akmatova",
            "Stefan Schmid" , "Emine Morina" , "Mircalla von Karnstein" ,"Marsha P.Johnson" , "RuPaul Andre Charles"
        };

        /// <summary>
        /// Nombre max de patients
        /// </summary>
        public const int MaxPatient = 4;
        
        
        /// <summary>
        /// Touche d'intéraction
        /// </summary>
        public const KeyCode InteractKey = KeyCode.E; 
    }
}