using UnityEngine;

namespace Fiche_Patient
{
    public class FichePatient : MonoBehaviour
    {
        public void Start()
        {
            Instantiate(Resources.Load<GameObject>("Prefabs/Fiche Patient"));
        }

        /*public void Update()
        {
            //dès qu'un patient rentre set Nom et Age a ceux du patient
            //dès que le patient se casse set tout les component textuel a "Client Suivant"
        }*/
    }
}