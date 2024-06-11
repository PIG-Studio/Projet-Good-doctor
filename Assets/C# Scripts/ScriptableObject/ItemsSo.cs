    using System.Reflection;
using UnityEngine;

namespace ScriptableObject
{
    [CreateAssetMenu(fileName = "item", menuName = "../Ressources/Prefabs/Item", order = 1)]
    public class ItemsSo : UnityEngine.ScriptableObject
    {
        public string title; 
        public string description;
        public Sprite icon;
        public int amount; 
        public bool isStackable;

        [System.Serializable] // pour afficher dans le script
        public enum Type
        {
            Quete, Medicament, Nourriture
        }

        public Type type;

        public ItemsSo(string _title, string _description, Sprite _icon, int _amount, bool _isStackable, Type _type)
        {
            title = _title;
            description = _description;
            icon = _icon;
            amount = _amount;
            isStackable = _isStackable;
            type = _type;
        }
    }
}
