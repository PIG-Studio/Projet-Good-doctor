using CustomScenes;
using GameCore.Variables;
using Inventories.Player;
using ScriptableObject;
using UnityEngine;

namespace Inventories.Desk
{
    public class DeskInventory : MonoBehaviour, IInventory
    {
        public ItemsSo[] Inventaire { get; set; }
        public string NomActuel { get; set; }
        public Sprite ImageActuel { get; set; }
        public string DescActuelle { get; set; }
        public uint QuantiteAUtiliser { get; set; }
        public uint QuantiteAct { get; set; }
        public uint MaxLenght { get => 24 ; }
        public void Start()
        {
            Inventaire = new ItemsSo[MaxLenght];
            
            NomActuel = null;
            ImageActuel = null;
            DescActuelle = null;
            QuantiteAct = 0;
            QuantiteAUtiliser = 0;
        }

        public void Update()
        {
            if (Variable.SceneNameCurrent == Scenes.DBase) //quand dans desk
            {
                transform.GetChild(0).gameObject.SetActive(true);

            }
            else
                // Si pas dans desk, fermer l'inventaire
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }

        public void UpdateDescription(uint i)
        {
            if (Inventaire[i] is null)
            {
                NomActuel = "";
                QuantiteAct = 0;
            }
            else
            {
                NomActuel = Inventaire[i].title;
                QuantiteAct = Inventaire[i].amount;
            }
        }

        public void AddItem(ItemsSo item)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveItem(ItemsSo item)
        {
            throw new System.NotImplementedException();
        }

        public void GiveItem(ItemsSo item, IInventory inventory)
        {
            throw new System.NotImplementedException();
        }
    }
}