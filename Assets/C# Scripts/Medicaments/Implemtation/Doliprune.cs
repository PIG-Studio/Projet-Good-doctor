using System;
using Medicaments.Base;
using UnityEngine;

namespace Medicaments.Implemtation
{
    public class Doliprune : Medicament
    {
        public Doliprune(uint qte) : base("Doliprune", () => { Console.WriteLine("Doliprune"); }, qte,
            Resources.Load<Sprite>("Sprites/Medicaments/mure")) //a changer
        { }
    }
}