using GameCore.Variables;
using Joueur.Base;
using Super.Interfaces.Joueur;
using TMPro;
using TypeExpand.String;
using UnityEngine;
using UnityEngine.UI;

namespace UI_Scripts.UI_Scenes.UI_Details
{
    public class Reputation : MonoBehaviour
    {
        private int _rep;
        [SerializeField]public JoueurFundamentals joueur;
        public void Start()
        {
            if (Variable.SceneNameCurrent.IsDesk())
            {
                joueur = Variable.SceneNameCurrent.ToDesk()!.Responsable as JoueurFundamentals;
            }
            _rep = joueur!.Reputation;
            transform.GetChild(4).GetComponent<TextMeshProUGUI>().text =
                "Reputation : " + _rep.ToString(); 
        }

        public void Update()
        {
            transform.GetChild(4).GetComponent<TextMeshProUGUI>().text =
                "Reputation : " + joueur.Reputation.ToString();
            transform.GetChild(0).GetComponent<Image>().enabled = _rep >= 75;
            transform.GetChild(1).GetComponent<Image>().enabled = _rep >= 50 &&  _rep < 75;
            transform.GetChild(2).GetComponent<Image>().enabled = _rep >= 25 && _rep < 50;
            transform.GetChild(3).GetComponent<Image>().enabled = _rep >= 0 && _rep < 25;
        }
    }
}