using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

namespace UI_Scripts.UI_Scenes.UI_Details
{
    public class Livre : MonoBehaviour
    {
        public void Start()
        {
            
            GetComponent<Image>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(3).gameObject.SetActive(true);
            transform.GetChild(2).transform.GetChild(0).GetComponent<Button>().onClick.AddListener(EncOnClick);
            transform.GetChild(3).transform.GetChild(0).GetComponent<Button>().onClick.AddListener(TutoOnClick);
        }

        void EncOnClick()
        {
            GetComponent<Image>().enabled = true;
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.AddComponent<Encyclopedie>();
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
        }
        void TutoOnClick()
        {
            GetComponent<Image>().enabled = true;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.AddComponent<Tutoriel>();
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
        }
    }
}