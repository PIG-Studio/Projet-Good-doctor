using Desks;
using Destinations.Implementation;
using GameCore.Variables;
using Super.Interfaces.Destination;
using Super.Interfaces.Entites;
using UnityEngine;

namespace Destinations.Lieux.Cafet
{
    public class Cafet
    {
        /// <summary>
        /// Méthode pour ajuster les variables après la création d'une destination de bureau
        /// </summary>
        /// <param name="bureauCree"></param>
        private static void AjustementVariables(INormalDestination bureauCree)
        {
            Variable.AllDestinations.Add(bureauCree);// Ajout de la destination à la liste de toutes les destinations
            // Ajout de la destination au dictionnaire des destinations de bureau
            Variable.NormalDestinations[bureauCree.DestId] = bureauCree;
            Debug.Log($"destination {bureauCree.DestId} initialisée ({bureauCree.DestId})"); // Affichage d'un message de débogage 
        }
        
        /// <summary>
        /// Méthode pour créer une destination de bureau de base
        /// </summary>
        /// <returns></returns>
        public static INormalDestination Dest_Cafet()
        {
            // Création de la destination avec des paramètres spécifiques
            NormalDestination retour = new NormalDestination(7, Vector2.zero,
                new (bool occupe, Vector2 coordonees, ICanGoInDestination occupant)[7], 0);
            
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
    }
}