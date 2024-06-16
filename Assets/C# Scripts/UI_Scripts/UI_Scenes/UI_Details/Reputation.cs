using GameCore.Variables;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI_Scripts.UI_Scenes.UI_Details
{
    public class Reputation : MonoBehaviour
    {
        private int _rep;
        public void Start()
        {
            _rep = Variable.CurrentlyRenderedDesk.Responsable.Reputation;
            transform.GetChild(4).GetComponent<TextMeshProUGUI>().text =
                "Reputation : " + _rep.ToString(); 
        }

        public void Update()
        {
            transform.GetChild(4).GetComponent<TextMeshProUGUI>().text =
                "Reputation : " + Variable.CurrentlyRenderedDesk.Responsable.Reputation.ToString();
            transform.GetChild(0).GetComponent<Image>().enabled = _rep >= 75;
            transform.GetChild(1).GetComponent<Image>().enabled = _rep >= 50 &&  _rep < 75;
            transform.GetChild(2).GetComponent<Image>().enabled = _rep >= 25 && _rep < 50;
            transform.GetChild(3).GetComponent<Image>().enabled = _rep >= 0 && _rep < 25;
        }
    }
}