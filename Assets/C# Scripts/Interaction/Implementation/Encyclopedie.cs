using GameCore.Constantes;
using ScriptableObject;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Interaction.Implementation
{
    public class Encyclopedie : MonoBehaviour
    {
        [FormerlySerializedAs("Photographie")] public SpriteRenderer photographie;

        [FormerlySerializedAs("Nom")] public TextMeshProUGUI nom;

        [FormerlySerializedAs("Description")] public TextMeshProUGUI description;

        [FormerlySerializedAs("Next")] public Button next;

        [FormerlySerializedAs("Before")] public Button before;

        private int Index { get; set; }
        
        public void Start()
        {
            before.enabled = false;
            Index = 0;
            next.onClick.AddListener(NextClick);
            before.onClick.AddListener(BeforeClick);
        }

        void HandleClick()
        {
            next.enabled = Index != Constante.Encyclopedies.Length - 1;
            before.enabled = Index != 0;
        }

        void NextClick()
        {
            if (Index >= Constante.Encyclopedies.Length - 1) return;
            Index++;
            ItemsSo aux = Constante.Encyclopedies[Index];
            photographie.sprite = aux.icon;
            nom.text = aux.title;
            description.text = aux.description;
            HandleClick();
        }

        void BeforeClick()
        {
            if (Index <= 0) return;
            Index--;
            ItemsSo aux = Constante.Encyclopedies[Index];
            photographie.sprite = aux.icon;
            nom.text = aux.title;
            description.text = aux.description;
            HandleClick();
        }
    }
}