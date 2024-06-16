using CustomScenes;
using Interaction.Base;
using UnityEngine;
using GameCore.Constantes;
using GameCore.Variables;
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
                
                Variable.CurrentlyRenderedDesk.Responsable.Inventory.AddItem(newItem);

                Destroy(gameObject); // Détruit l'objet ramassé
            }
        }
    
    }
}

