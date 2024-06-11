using System;
using System.Collections.Generic;
using CustomScenes;
using GameCore.Variables;
using Medicaments.Base;
using Medicaments.Implemtation;
using ScriptableObject;
using TMPro;
using UI_Scripts.UI_Prefab.UI_Base;
using UI_Scripts.UI_Prefab.UI_Objects;
using UnityEditor.VersionControl;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Windows;
using Image = UnityEngine.UIElements.Image;
using Object = UnityEngine.Object;
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