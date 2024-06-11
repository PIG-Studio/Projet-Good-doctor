using Interfaces;
using UnityEngine;

namespace PNJ
{
    public static class AnimatorLink
    {
        public static void LinkAnimator(this ISpawnableGo input)
        {
            // Récupérer le composant Animator de l'objet instancié
            Animator anims = input.InstantiatedObject.GetComponent<Animator>();
            // Lier l'Animator à l'objet instancié
            input.AnimatorComponent = anims; 
        }
    }
}