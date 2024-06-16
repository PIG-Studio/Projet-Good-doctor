    using System.Reflection;
    using Image = UnityEngine.UI.Image;
    using UnityEngine;

namespace ScriptableObject
{
    [CreateAssetMenu(fileName = "item", menuName = "../Ressources/Prefabs/Item", order = 1)]
    public class ItemsSo : UnityEngine.ScriptableObject
    {
        public string title; 
        public string description;
        public Sprite icon;
        public uint amount; 
        public bool isStackable;

        [System.Serializable] // pour afficher dans le script
        public enum Type
        {
            Quete, Medicament, Nourriture
        }

        public Type type;

        public bool AdnToNormal;
        public int ModifyFreqCar;
        public int ModifyTemp;
        public int ModifyEmotion;
        public bool Deadly;

        public uint Price;

        public ItemsSo CopyItem()
        {
            ItemsSo newItem = UnityEngine.ScriptableObject.CreateInstance<ItemsSo>();
            
            newItem.title = title;
            newItem.description = description;
            newItem.amount = amount;
            newItem.icon = icon;
            newItem.isStackable = isStackable;
            newItem.type = type;
            newItem.Deadly = Deadly;
            newItem.AdnToNormal = AdnToNormal;
            newItem.ModifyEmotion = ModifyEmotion;
            newItem.ModifyTemp = ModifyTemp;
            newItem.ModifyFreqCar = ModifyFreqCar;
            newItem.Price = Price;

            return newItem;
        }
    }
}
