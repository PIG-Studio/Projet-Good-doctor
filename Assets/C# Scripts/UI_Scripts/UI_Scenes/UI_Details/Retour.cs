using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI_Scripts.UI_Scenes.UI_Details
{
    public class Retour : MonoBehaviour
    {
        public void RetourOnClick()
        {
            var parent = transform.parent;
            parent.GetChild(0).gameObject.SetActive(false);
            parent.GetChild(1).gameObject.SetActive(false);
            parent.GetChild(2).gameObject.SetActive(true);
            parent.GetChild(3).gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}