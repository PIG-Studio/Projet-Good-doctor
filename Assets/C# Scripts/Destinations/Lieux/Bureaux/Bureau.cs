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
            DeskDestination retour = new DeskDestination(3, Vector2.zero,
                new (bool occupe, Vector2 coordonees, ICanGoInDestination occupant)[3], input, 0);
            
            // Ajout des differentes coordonnées
            retour.PtArrivee = new Vector2(-7, -10);
            retour.PtAttente[0].coordonees = new Vector2(-10, -10);
            retour.PtAttente[1].coordonees = new Vector2(-13, -10);
            retour.PtAttente[2].coordonees = new Vector2(-16, -10);
            
            AjustementVariables(retour); // Appel de la méthode pour ajuster les variables
            
            return retour;
        }
        
        /// <summary>
        /// Méthode pour créer une destination de bureau améliorée
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static IDeskDestination DESK_Upgraded(Desk input)
        {
            // Création de la destination avec des paramètres spécifiques
            DeskDestination retour = new DeskDestination(1, Vector2.zero,
                new (bool occupe, Vector2 coordonees, ICanGoInDestination occupant)[3], input, 1);
            
            // Ajout des différentes coordonnées
            retour.PtArrivee = new Vector2(-7, 0);
            retour.PtAttente[0].coordonees = new Vector2(-8, 0);
            
            AjustementVariables(retour); // Appel de la méthode pour ajuster les variables
            
            return retour;
        }
    }
}