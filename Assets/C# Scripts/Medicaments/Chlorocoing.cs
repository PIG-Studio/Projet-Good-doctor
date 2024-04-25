using System;
using UnityEngine;

namespace C__Scripts.Medicaments
{
    public class Chlorocoing : Medicament
    {
        public Chlorocoing(uint qte) : base("Chlorocoing", () => { Console.WriteLine("Chlorocoing"); }, qte,
            Resources.Load<Sprite>("Sprites/Medicaments/mure"))
        { }
    }
}