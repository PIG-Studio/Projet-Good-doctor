using Unity.Netcode;
using UnityEngine;
using UnityEngine.AI;

namespace Super.Abstract
{
    public abstract class ARender: NetworkBehaviour
    {
        protected abstract SpriteRenderer Sprite { get; set; }
        protected abstract Animator Anims{ get; set; }
        protected abstract Rigidbody2D Rb { get; set; }
    }
}