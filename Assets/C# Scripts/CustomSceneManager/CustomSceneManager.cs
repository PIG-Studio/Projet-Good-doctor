using UnityEditor.Build.Reporting;
using UnityEngine.SceneManagement;
using UnityEngine;

/// <summary>
/// Les methodes de bases na permettent pas de changer certaines variables lors du changement de scene, on refait donc nos propres methodes.
/// </summary>
public class CustomSceneManager: MonoBehaviour
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
        GameVariables.SceneName_Last = SceneManager.GetActiveScene().name;
        GameVariables.SceneName_Current = newScene;
        Debug.Log($"CustomSceneManager.ChangeScene() : {GameVariables.SceneName_Last} -> {GameVariables.SceneName_Current}");
        // On change les variables enregistrant la scene actuelle et la scene precedente
        
        SceneManager.LoadScene(newScene);
        // On charge la nouvelle scene
    }
    
    /// <summary>
    /// Call to this method to leave game
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
