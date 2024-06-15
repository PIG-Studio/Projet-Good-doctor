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
            NormalDestination retour = new NormalDestination(6, Vector2.zero,
                new (bool occupe, Vector2 coordonees, ICanGoInDestination occupant)[6], 1);
            
            // Ajout des differentes coordonnées
            retour.PtArrivee = new Vector2(35f, -12f);
            retour.PtAttente[0].coordonees = new Vector2(40f, -4.5f);
            retour.PtAttente[1].coordonees = new Vector2(46f, -4.5f);
            retour.PtAttente[2].coordonees = new Vector2(48f, -4.5f);
            retour.PtAttente[3].coordonees = new Vector2(51f, -4.5f);
            retour.PtAttente[4].coordonees = new Vector2(46.5f, -8f);
            retour.PtAttente[5].coordonees = new Vector2(41f, -9f);
            
            
            AjustementVariables(retour); // Appel de la méthode pour ajuster les variables
            
            return retour;
        }
    }
}