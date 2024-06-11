using GameCore.Variables;
using CustomScenes;
using UnityEngine;
using Parameters;
using TypeExpand.String;

namespace Interaction.Implementation
{
    /// <summary>
    /// Classe permettant de gérer l'interaction pour entrer dans un bureau
    /// </summary>
    public class RentrerDansBureau : MonoBehaviour
    {
        public string bureau;
        
        /// <summary>
        /// Méthode appelée lorsque le collider reste en collision avec un autre collider 2D
        /// </summary>
        /// <param name="other"></param>
        public void OnTriggerStay2D(Collider2D other)
        {
            // Vérifie si la touche définie dans Keys.UseKey est enfoncée
            if (Input.GetKeyDown(Keys.UseKey)){Debug.Log("E key was pressed");} // Affiche un message pour indiquer que la touche "E" a été pressée
            
            // Vérifie si le collider en collision a le tag "Player"
            if (other.CompareTag("Player")){Debug.Log("Player touched");} // Affiche un message pour indiquer que le joueur a été touché
            
            // Vérifie si la touche définie dans Keys.UseKey est enfoncée ET si le collider en collision a le tag "Player"
            if (Input.GetKeyDown(Keys.UseKey) && other.CompareTag("Player"))
            {
                // Change la scène vers la scène associée au bureau dans Variable.Desk.SceneName
                Manager.ChangeScene(bureau.ToDesk()!.SceneName);
            }
        }
    }
}