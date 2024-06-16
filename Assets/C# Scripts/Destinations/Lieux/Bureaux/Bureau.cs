using Desks;
using Destinations.Implementation;
using GameCore.Variables;
using Super.Interfaces.Destination;
using Super.Interfaces.Entites;
using UnityEngine;

namespace Destinations.Lieux.Bureaux
{
    public class Bureau
    {
        /// <summary>
        /// Méthode pour ajuster les variables après la création d'une destination de bureau
        /// </summary>
        /// <param name="bureauCree"></param>
        private static void AjustementVariables(IDeskDestination bureauCree)
        {
            Variable.AllDestinations.Add(bureauCree);// Ajout de la destination à la liste de toutes les destinations
            // Ajout de la destination au dictionnaire des destinations de bureau
            Variable.DeskDestinations[bureauCree.DestId] = bureauCree;
            Debug.Log($"destination {bureauCree.DestId} initialisée ({bureauCree.Bureau.SceneName})"); // Affichage d'un message de débogage 
        }
        
        /// <summary>
        /// Méthode pour créer une destination de bureau de base
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static IDeskDestination DESK_Base(Desk input)
        {
            // Création de la destination avec des paramètres spécifiques
            DeskDestination retour = new DeskDestination(7, Vector2.zero,
                new (bool occupe, Vector2 coordonees, ICanGoInDestination occupant)[7], input, 0);
            
            // Ajout des differentes coordonnées
            retour.PtArrivee = new Vector2(-12f, -33f);
            retour.PtAttente[0].coordonees = new Vector2(-23.5f, -53f);
            retour.PtAttente[1].coordonees = new Vector2(-26.5f, -53f);
            retour.PtAttente[2].coordonees = new Vector2(-30.5f, -53f);
            retour.PtAttente[3].coordonees = new Vector2(-31f, -56f);
            retour.PtAttente[4].coordonees = new Vector2(-28f, -56f);
            retour.PtAttente[5].coordonees = new Vector2(-25f, -56f);
            retour.PtAttente[6].coordonees = new Vector2(-22f, -56f);
            
            
            AjustementVariables(retour); // Appel de la méthode pour ajuster les variables
            
            return retour;
        }
        
        /// <summary>
        /// Méthode pour créer une destination de bureau améliorée
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static IDeskDestination DESK_2(Desk input)
        {
            // Création de la destination avec des paramètres spécifiques
            DeskDestination retour = new DeskDestination(6, Vector2.zero,
                new (bool occupe, Vector2 coordonees, ICanGoInDestination occupant)[6], input, 1);
            
            // Ajout des différentes coordonnées
            retour.PtArrivee = new Vector2(-25f, -33f);
            retour.PtAttente[0].coordonees = new Vector2(-15f, -52.5f);
            retour.PtAttente[1].coordonees = new Vector2(-15f, -54.5f);
            retour.PtAttente[2].coordonees = new Vector2(-15f, -56.5f);
            retour.PtAttente[3].coordonees = new Vector2(-15f, -58.5f);
            retour.PtAttente[4].coordonees = new Vector2(-16.25f, -59.5f);
            retour.PtAttente[5].coordonees = new Vector2(-18.25f, -59.5f);
            
            
            AjustementVariables(retour); // Appel de la méthode pour ajuster les variables
            
            return retour;
        }
        /// <summary>
        /// Méthode pour créer une destination de bureau améliorée
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static IDeskDestination DESK_3(Desk input)
        {
            // Création de la destination avec des paramètres spécifiques
            DeskDestination retour = new DeskDestination(6, Vector2.zero,
                new (bool occupe, Vector2 coordonees, ICanGoInDestination occupant)[6], input, 2);
            
            // Ajout des différentes coordonnées
            retour.PtArrivee = new Vector2(-35f, -33f);
            retour.PtAttente[0].coordonees = new Vector2(-20.25f, -59.5f);
            retour.PtAttente[1].coordonees = new Vector2(-22.25f, -59.5f);
            retour.PtAttente[2].coordonees = new Vector2(-24.25f, -59.5f);
            retour.PtAttente[3].coordonees = new Vector2(-28.25f, -59.5f);
            retour.PtAttente[4].coordonees = new Vector2(-30.25f, -59.5f);
            retour.PtAttente[5].coordonees = new Vector2(-32.25f, -59.5f);
            
            
            AjustementVariables(retour); // Appel de la méthode pour ajuster les variables
            
            return retour;
        }
        /// <summary>
        /// Méthode pour créer une destination de bureau améliorée
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static IDeskDestination DESK_4(Desk input)
        {
            // Création de la destination avec des paramètres spécifiques
            DeskDestination retour = new DeskDestination(6, Vector2.zero,
                new (bool occupe, Vector2 coordonees, ICanGoInDestination occupant)[6], input, 3);
            
            // Ajout des différentes coordonnées
            retour.PtArrivee = new Vector2(-52f, -36f);
            retour.PtAttente[0].coordonees = new Vector2(-34.25f, -47.5f);
            retour.PtAttente[1].coordonees = new Vector2(-34.25f, -52.5f);
            retour.PtAttente[2].coordonees = new Vector2(-34.25f, -54.5f);
            retour.PtAttente[3].coordonees = new Vector2(-34.25f, -56.5f);
            retour.PtAttente[4].coordonees = new Vector2(-35.5f, -59.4f);
            retour.PtAttente[5].coordonees = new Vector2(-24f, -46.75f);
            
            AjustementVariables(retour); // Appel de la méthode pour ajuster les variables
            
            return retour;
        }
    }
}