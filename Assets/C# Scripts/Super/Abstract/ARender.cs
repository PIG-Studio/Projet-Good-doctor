using Unity.Netcode;
using UnityEngine;

namespace Super.Abstract
{
    public abstract class ARender: NetworkBehaviour
    {
        protected SpriteRenderer SpriteRenderer { get; set; }
        protected Animator Anims{ get; set; }
    }
}