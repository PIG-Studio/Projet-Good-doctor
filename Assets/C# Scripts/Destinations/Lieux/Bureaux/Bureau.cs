using Desks;
using Destinations.Implementation;
using GameCore.Variables;
using Interfaces.Destination;
using Interfaces.Entites;
using UnityEngine;

namespace Destinations.Lieux.Bureaux
{
    public class Bureau
    {
        private static void AjustementVariables(IDeskDestination bureauCree)
        {
            Variable.AllDestinations.Add(bureauCree);
            Variable.DeskDestinations[bureauCree.DeskId] = bureauCree;
            Debug.Log($"destination {bureauCree.DeskId} initialisée ({bureauCree.Bureau.SceneName})"); 
        }
        
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
            
            AjustementVariables(retour);
            
            return retour;
        }
        
        public static IDeskDestination DESK_Upgraded(Desk input)
        {
            // Création de la destination avec des paramètres spécifiques
            DeskDestination retour = new DeskDestination(1, Vector2.zero,
                new (bool occupe, Vector2 coordonees, ICanGoInDestination occupant)[3], input, 1);
            
            // Ajout des differentes coordonnées
            retour.PtArrivee = new Vector2(-7, 0);
            retour.PtAttente[0].coordonees = new Vector2(-8, 0);
            
            AjustementVariables(retour);
            
            return retour;
        }
    }
}