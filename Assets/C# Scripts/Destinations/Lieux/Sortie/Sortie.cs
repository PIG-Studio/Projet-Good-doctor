using Destinations.Implementation;
using GameCore.Variables;
using Interfaces.Destination;
using Interfaces.Entites;
using UnityEngine;

namespace Destinations.Lieux.Sortie
{
    public class Sortie
    {
        /// <summary>
        /// Méthode pour ajuster les variables après la création d'une destination de bureau
        /// </summary>
        /// <param name="destCree"></param>
        private static void AjustementVariables(NormalDestination destCree)
        {
            // Ajout de la destination au dictionnaire des destinations de bureau
            Variable.NormalDestinations[destCree.DestId] = destCree;
            Debug.Log($"destination {destCree.DestId} initialisée ({destCree})"); // Affichage d'un message de débogage 
        }
        
        public static INormalDestination Dest_Sortie()
        {
            // Création de la destination avec des paramètres spécifiques
            NormalDestination retour = new NormalDestination(6, new Vector2(3, 4),
                new (bool occupe, Vector2 coordonees, ICanGoInDestination occupant)[6], 0);
            
            // Ajout des differentes coordonnées
            retour.PtAttente[0].coordonees = new Vector2(-10, -10);
            retour.PtAttente[1].coordonees = new Vector2(-13, -10);
            retour.PtAttente[2].coordonees = new Vector2(-16, -10);
            retour.PtAttente[3].coordonees = new Vector2(-10, -10);
            retour.PtAttente[4].coordonees = new Vector2(-13, -10);
            retour.PtAttente[5].coordonees = new Vector2(-16, -10);
            
            AjustementVariables(retour); // Appel de la méthode pour ajuster les variables
            
            return retour;
        }
    }
}