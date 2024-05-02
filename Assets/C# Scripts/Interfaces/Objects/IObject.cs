using UnityEngine;

namespace Interfaces.Objects
{
    public interface IObject
    {
        string Name { get; set; }
        uint Amount { get; set; }
        Sprite Image { get; set; }

        
    }
}