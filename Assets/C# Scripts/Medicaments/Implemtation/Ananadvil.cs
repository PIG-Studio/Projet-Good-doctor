using System;
using Medicaments.Base;
using UnityEngine;

namespace Medicaments.Implemtation
{
    public class Ananadvil : Medicament
    {
        public Ananadvil(uint qte) : base("Ananadvil", () => { Console.WriteLine("Ananadvil"); }, qte,
            Resources.Load<Sprite>("Sprites/Medicaments/mure"))
        { }
    }
}