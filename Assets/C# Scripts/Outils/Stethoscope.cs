using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Outils
{
    public class Stethoscope : MonoBehaviour
    {
        private static Object _stethoscope;
        public GameObject Freq;

        void StethoOnClick()
        { 
            Debug.Log("Clique !");
            Freq.GetComponent<TextMeshProUGUI>().text = 120 + " BPM";
        }

        public void Start()
        {
            _stethoscope = Resources.Load("Prefabs/Outils/Stethoscope");
            Instantiate(_stethoscope);
            FindObjectOfType<Button>().onClick.AddListener(StethoOnClick);

        }
    }
}