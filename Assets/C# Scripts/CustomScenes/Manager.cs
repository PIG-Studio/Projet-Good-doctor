using GameCore;
using GameCore.TypeExpand;
using UnityEngine.SceneManagement;
using UnityEngine;
using static GameCore.Variables;

namespace CustomScenes
{

    /// <summary>
    /// Les methodes de bases na permettent pas de changer certaines variables lors du changement de scene, on refait donc nos propres methodes.
    /// </summary>
    public static class Manager
    {

        /// <summary>
        /// etat potentiellement utile pour avoir l etat de selection des boutons/champs de texte
        /// </summary>
        private static bool _selected = false;


        /// <summary>
        /// methode a utiliser pour changer de scene
        /// </summary>
        /// <param name="newScene">type: Scene; nom de la nouvelle scene</param>
        public static void ChangeScene(string newScene)
        {
            // On change les variables enregistrant la scene actuelle et la scene precedente
            SceneName_Last = SceneManager.GetActiveScene().name;
            SceneName_Current = newScene;
            Debug.Log($"CustomSceneManager.ChangeScene() : {SceneName_Last} -> {SceneName_Current}");

            // On actualise le bureau actuel
            if (SceneName_Current.IsDesk())
            { 
                CurrentlyRenderedDesk = SceneName_Current.ToDesk();
            }

            // On charge la nouvelle scene
            SceneManager.LoadScene(newScene);
        }

        /// <summary>
        /// Methode pour couper le jeu
        /// </summary>
        public static void Quit()
        {
            Application.Quit();
        }

        /// <summary>
        /// Not used yet
        /// </summary>
        public static void ChangeSelect()
        {
            _selected = !_selected;
        }
    }
}