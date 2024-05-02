using TypeExpand.String;
using UnityEngine.SceneManagement;
using UnityEngine;
using static GameCore.GameVAR.Variables;

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
        private static bool _selected;


        /// <summary>
        /// methode a utiliser pour changer de scene
        /// </summary>
        /// <param name="newScene">type: Scene; nom de la nouvelle scene</param>
        public static void ChangeScene(string newScene)
        {
            // On change les variables enregistrant la scene actuelle et la scene precedente
            SceneNameLast = SceneManager.GetActiveScene().name;
            SceneNameCurrent = newScene;
            Debug.Log($"CustomSceneManager.ChangeScene() : {SceneNameLast} -> {SceneNameCurrent}");

            // On actualise le bureau actuel
            if (SceneNameCurrent.IsDesk())
            {
                CurrentlyRenderedDesk = SceneNameCurrent.ToDesk();
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