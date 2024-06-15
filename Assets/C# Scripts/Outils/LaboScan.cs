using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Outils
{
    public class LaboScan : MonoBehaviour
    {
        private static Object _labo;
        public GameObject ADN;

        void LaboOnClick()
        { 
            Debug.Log("Clique !");
            ADN.GetComponent<TextMeshProUGUI>().text = "cgattagc";
        }

        public void Start()
        {
            _labo = Resources.Load("Prefabs/Outils/Labo");
            Instantiate(_labo);
            FindObjectOfType<Button>().onClick.AddListener(LaboOnClick);

        }
    }
}