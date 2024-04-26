using System;
using Medicaments.Base;
using UnityEngine;

namespace Medicaments.Implemtation
{
    public class Oxycodatte: Medicament
    {
        public Oxycodatte(uint qte) : base("Oxycodatte", () => { Console.WriteLine("Oxycodatte"); }, qte,
            Resources.Load<Sprite>("Sprites/Medicaments/dattes"))
        { }
    }
}