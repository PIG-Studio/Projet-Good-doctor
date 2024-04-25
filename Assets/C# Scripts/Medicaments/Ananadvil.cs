using System;
using UnityEngine;

namespace C__Scripts.Medicaments
{
    public class Ananadvil : Medicament
    {
        public Ananadvil(uint qte) : base("Ananadvil", () => { Console.WriteLine("Ananadvil"); }, qte,
            Resources.Load<Sprite>("Sprites/Medicaments/mure"))
        { }
    }
}