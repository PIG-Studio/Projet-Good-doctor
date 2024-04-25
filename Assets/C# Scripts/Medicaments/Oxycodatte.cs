using System;
using UnityEngine;

namespace C__Scripts.Medicaments
{
    public class Oxycodatte: Medicament
    {
        public Oxycodatte(uint qte) : base("Oxycodatte", () => { Console.WriteLine("Oxycodatte"); }, qte,
            Resources.Load<Sprite>("Sprites/Medicaments/mure"))
        { }
    }
}