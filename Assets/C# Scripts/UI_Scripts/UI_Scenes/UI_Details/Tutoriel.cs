using GameCore.Constantes;
using ScriptableObject;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI_Scripts.UI_Scenes.UI_Details
{
    public class Tutoriel : MonoBehaviour
    {
        private int Index { get; set; }
        
        public void Start()
        {
            Index = -1;
            transform.GetChild(1).GetComponent<Button>().enabled = false;
            transform.GetChild(0).GetComponent<Button>().onClick.AddListener(NextClick);
            transform.GetChild(1).GetComponent<Button>().onClick.AddListener(BeforeClick);
            transform.GetChild(5).GetComponent<Button>().onClick.AddListener(Retour);
        }

        void HandleClick()
        {
            transform.GetChild(0).GetComponent<Button>().enabled = Index != Constante.TutoImages.Length - 1;
            transform.GetChild(1).GetComponent<Button>().enabled = Index != 0;
        }

        void NextClick()
        {
            if (Index >= Constante.TutoImages.Length - 1) return;
            Index++;
            transform.GetChild(4).GetComponent<Image>().sprite =
                Resources.Load<Sprite>(Constante.TutoImages[Index]);
            transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = Constante.TexteTuto[Index][0];
            transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = Constante.TexteTuto[Index][1];
            HandleClick();
        }

        void BeforeClick()
        {
            if (Index <= 0) return;
            Index--;
            transform.GetChild(4).GetComponent<Image>().sprite =
                Resources.Load<Sprite>(Constante.TutoImages[Index]);
            transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = Constante.TexteTuto[Index][0];
            transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = Constante.TexteTuto[Index][1];
            HandleClick();
        }
        
        void Retour()
        {
            Debug.Log("Retour");
            var parent = transform.parent;
            parent.GetComponent<UnityEngine.UI.Image>().enabled = false;
            parent.GetChild(3).gameObject.SetActive(true);
            parent.GetChild(2).gameObject.SetActive(true);
            parent.GetChild(0).gameObject.SetActive(false);
            parent.GetChild(1).gameObject.SetActive(false);
        }
    }
}