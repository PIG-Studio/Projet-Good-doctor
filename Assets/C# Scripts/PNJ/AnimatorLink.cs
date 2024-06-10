using Interfaces;
using UnityEngine;

namespace PNJ
{
    public static class AnimatorLink
    {
        public static void LinkAnimator(this ISpawnableGo input)
        {
            Animator anims = input.InstantiatedObject.GetComponent<Animator>();// Récupérer le composant Animator
            input.AnimatorComponent = anims; 
        }
    }
}