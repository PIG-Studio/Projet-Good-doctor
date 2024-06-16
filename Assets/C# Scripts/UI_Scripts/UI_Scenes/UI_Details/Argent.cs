using GameCore.Variables;
using TMPro;
using UnityEngine;

namespace UI_Scripts.UI_Scenes.UI_Details
{
    public class Argent : MonoBehaviour
    {
        private uint _money;

        public void Start()
        {
            _money = Variable.CurrentlyRenderedDesk.Responsable.Money;
            transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = _money +  "\u20ac ";
        }

        public void Update()
        {
            _money = Variable.CurrentlyRenderedDesk.Responsable.Money;
            transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = _money +  "\u20ac ";

        }
    }
}