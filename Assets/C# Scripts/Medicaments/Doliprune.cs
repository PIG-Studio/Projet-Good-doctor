using System;
using UnityEngine;

namespace C__Scripts.Medicaments
{
    public class Doliprune : Medicament
    {
        public Doliprune(uint qte) : base("Doliprune", () => { Console.WriteLine("Doliprune"); }, qte,
            Resources.Load<Sprite>("Sprites/Medicaments/mure")) //a changer
        { }
    }
}