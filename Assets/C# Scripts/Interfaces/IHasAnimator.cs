using UnityEngine;

namespace Interfaces
{
    public interface IHasAnimator
    {
        Animator AnimatorComponent { get; set; }
    }
}