using Super.Interfaces.Joueur;
using Super.Interfaces.Patient;
using UnityEngine;
using UnityEngine.Serialization;

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

        [FormerlySerializedAs("AdnToNormal")] public bool adnToNormal;
        [FormerlySerializedAs("ModifyFreqCar")] public int modifyFreqCar;
        [FormerlySerializedAs("ModifyTemp")] public int modifyTemp;
        [FormerlySerializedAs("ModifyEmotion")] public int modifyEmotion;
        [FormerlySerializedAs("Deadly")] public bool deadly;

        [FormerlySerializedAs("Price")] public uint price;

        public ItemsSo CopyItem()
        {
            ItemsSo newItem = CreateInstance<ItemsSo>();
            
            newItem.title = title;
            newItem.description = description;
            newItem.amount = amount;
            newItem.icon = icon;
            newItem.isStackable = isStackable;
            newItem.type = type;
            
            newItem.deadly = deadly;
            newItem.adnToNormal = adnToNormal;
            newItem.modifyEmotion = modifyEmotion;
            newItem.modifyTemp = modifyTemp;
            newItem.modifyFreqCar = modifyFreqCar;
            newItem.price = price;

            return newItem;
        }

        public void ModifyStat(IPatient patient)
        {
            patient.Depression.Valeur += (uint)modifyEmotion;
            patient.Temperature.Valeur += (uint)modifyTemp;
            patient.Adn.isHealthy = adnToNormal;
            patient.FreqCar.Valeur += (uint)modifyFreqCar;
        }

        public void ModifyStat(IJoueur joueur)
        {
            if (deadly)
                joueur.Pv -= 20;
            
            if (joueur.Pv <= 0)
            {
               //tuer joueur, fin de partie 
            }
        }
    }
}
