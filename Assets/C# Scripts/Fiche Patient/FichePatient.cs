using System;
using UnityEngine;

namespace Fiche_Patient
{
    public class FichePatient : MonoBehaviour
    {
        public void Start()
        {
            Instantiate(Resources.Load<GameObject>("Prefabs/Fiche Patient"));
        }
    }
}