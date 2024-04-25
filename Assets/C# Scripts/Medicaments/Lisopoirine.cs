using System;
using UnityEngine;

namespace C__Scripts.Medicaments
{
    public class Lisopoirine : Medicament
    {
        public Lisopoirine(uint qte) : base("Lisopoirine", () => { Console.WriteLine("Lisopoirine"); }, qte,
            Resources.Load<Sprite>("Sprites/Medicaments/mure"))
        { }
    }
}