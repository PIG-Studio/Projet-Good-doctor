namespace GameCore
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
        /// La derniere positon du joueur, actualise lorsque le joueur sort de la map ou va dans le menu pause, utile pour sauvegarder la position 
        /// </summary>
        /// <returns>type: (float, float)</returns>
        public static (float, float) LatestPos { get; set; }

        /// <summary>
        /// nom de la scene active
        /// </summary>
        /// <returns>type: string</returns>
        public static string SceneName_Current { get; set; }

        /// <summary>
        /// nom de la derniere scene, utile pour ouvrir les param n'importe quand et revenir sur la scene precedente
        /// </summary>
        /// <returns>type: string</returns>
        public static string SceneName_Last { get; set; }
    }
}