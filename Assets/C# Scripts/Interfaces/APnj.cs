using Unity.Netcode;
using UnityEngine;

namespace Interfaces
{
    public abstract class APnj: NetworkBehaviour
    {
        public abstract Sprite Skin { get; protected set; }
        public abstract string Name { get; protected set; }
        public abstract Vector2 Position { get; protected set; }
    }
}