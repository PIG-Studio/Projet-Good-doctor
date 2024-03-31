using UnityEngine;

namespace Interfaces
{
    public interface IObject
    {
        string Name { get; set; }
        int Amount { get; set; }
        Sprite Image { get; set; }

        bool Usable()
        {
            if (Amount > 0) { return true; }
            return false;
        }
        
        void Use();
    }
}