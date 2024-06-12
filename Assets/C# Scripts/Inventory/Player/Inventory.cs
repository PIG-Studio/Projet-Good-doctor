using System.Collections.Generic;
using ScriptableObject;

namespace Inventory.Player
{
    public interface Inventory
    {
        public List<ItemsSo> inventaire { get; set; }
        
    }
}