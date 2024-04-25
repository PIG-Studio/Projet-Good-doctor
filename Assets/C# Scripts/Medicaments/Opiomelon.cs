using System;
using UnityEngine;

namespace C__Scripts.Medicaments
{
    public class Opiomelon : Medicament
    {
        public Opiomelon(uint qte) : base("Opiomelon", () => { Console.WriteLine("Opiomelon"); }, qte,
            Resources.Load<Sprite>("Sprites/Medicaments/mure"))
        { }
    }
}