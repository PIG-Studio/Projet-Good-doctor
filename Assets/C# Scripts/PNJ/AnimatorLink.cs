using Interfaces;
using UnityEngine;

namespace PNJ
{
    public static class AnimatorLink
    {
        public static void LinkAnimator(this ISpawnableGo input)
        {
            Animator anims = input.InstantiatedObject.GetComponent<Animator>();
            input.AnimatorComponent = anims;
        }
    }
}