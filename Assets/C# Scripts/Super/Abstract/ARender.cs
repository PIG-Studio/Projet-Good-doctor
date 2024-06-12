using Unity.Netcode;
using UnityEngine;

namespace Super.Abstract
{
    public abstract class ARender: NetworkBehaviour
    {
        protected abstract SpriteRenderer Sprite { get; set; }
        protected abstract Animator Anims{ get; set; }
    }
}