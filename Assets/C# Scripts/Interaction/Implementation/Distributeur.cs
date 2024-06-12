using CustomScenes;
using Interaction.Base;
using UnityEngine;
using GameCore.Constantes;
using InventoryTwo.Player;
using Parameters;
using ScriptableObject;


namespace Interaction.Implementation
{
    public class Distributeur : ObjectInteraction
    {
        /// <summary>
        /// Méthode appelée pour interagir avec le distributeur
        /// </summary>
        
        public void OnTriggerStay2D(Collider2D other)
        {
            if (Input.GetKeyDown(Keys.UseKey) && other.CompareTag("Player"))
            {
                // FAIT POP UNE MADELAINE DANS INVENTAIRE
                if (!other.CompareTag("Player")) return;
                ItemsSo item = Resources.Load<ItemsSo>("Prefabs/Item/Madeleine.asset");
                ItemsSo newItem = UnityEngine.ScriptableObject.CreateInstance<ItemsSo>();
                newItem.title = item.title;
                newItem.description = item.description;
                newItem.amount = item.amount;
                newItem.icon = item.icon;
                newItem.isStackable = item.isStackable;
                newItem.type = item.type;
            
                for (int i = 0; i < InventoryManager.Instance.inventory.Count; i++)
                {
                    if (item.title == InventoryManager.Instance.inventory[i].title && item.isStackable &&
                        InventoryManager.Instance.inventory.Count > 0)
                    {
                        newItem.amount += InventoryManager.Instance.inventory[i].amount;
                        InventoryManager.Instance.inventory.Remove(InventoryManager.Instance.inventory[i]);
                    }
                }
                InventoryManager.Instance.inventory.Add(newItem);// Ajoute l'objet à l'inventaire

                Destroy(gameObject); // Détruit l'objet ramassé
            }
        }
    
    }
}

