using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Outils
{
    public class Depression : MonoBehaviour
    {
        private static Object _mood;
        public GameObject Mood;

        void MoodOnClick()
        { 
            Debug.Log("Clique !");
            Mood.GetComponent<TextMeshProUGUI>().text = "70";
        }

        public void Start()
        {
            _mood = Resources.Load("Prefabs/Outils/Depression");
            Instantiate(_mood);
            FindObjectOfType<Button>().onClick.AddListener(MoodOnClick);

        }
    }
}