using ScriptableObject;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using GameCore.Constantes;

namespace Interaction
{
    public class Encyclopedie : MonoBehaviour
    {
        public SpriteRenderer Photographie;

        public TextMeshProUGUI Nom;

        public TextMeshProUGUI Description;

        public Button Next;

        public Button Before;

        private int Index { get; set; }
        
        public void Start()
        {
            Before.enabled = false;
            Index = 0;
            Next.onClick.AddListener(NextClick);
            Before.onClick.AddListener(BeforeClick);
        }

        void HandleClick()
        {
            Next.enabled = Index != Constante.Encyclopedies.Length - 1;
            Before.enabled = Index != 0;
        }

        void NextClick()
        {
            if (Index >= Constante.Encyclopedies.Length - 1) return;
            Index++;
            ItemsSo aux = Constante.Encyclopedies[Index];
            Photographie.sprite = aux.icon;
            Nom.text = aux.title;
            Description.text = aux.description;
            HandleClick();
        }

        void BeforeClick()
        {
            if (Index <= 0) return;
            Index--;
            ItemsSo aux = Constante.Encyclopedies[Index];
            Photographie.sprite = aux.icon;
            Nom.text = aux.title;
            Description.text = aux.description;
            HandleClick();
        }
    }
}