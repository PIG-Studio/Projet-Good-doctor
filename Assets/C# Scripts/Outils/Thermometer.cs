using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Outils
{
    public class Thermometer : MonoBehaviour
    {
        private static Object _thermometer;
        public GameObject Temp;

        void ThermhoOnClick()
        { 
            Debug.Log("Clique !");
            Temp.GetComponent<TextMeshProUGUI>().text = 35 + " °c";
        }

        public void Start()
        {
            _thermometer = Resources.Load("Prefabs/Outils/Thermometer");
            Instantiate(_thermometer);
            FindObjectOfType<Button>().onClick.AddListener(ThermhoOnClick);

        }
    }
}