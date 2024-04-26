using System;
using Medicaments.Base;
using UnityEngine;

namespace Medicaments.Implemtation
{
    public class Lisopoirine : Medicament
    {
        public Lisopoirine(uint qte) : base("Lisopoirine", () => { Console.WriteLine("Lisopoirine"); }, qte,
            Resources.Load<Sprite>("Sprites/Medicaments/mure"))
        { }
    }
}