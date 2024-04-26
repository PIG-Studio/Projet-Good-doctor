using System;
using Medicaments.Base;
using UnityEngine;

namespace Medicaments.Implemtation
{
    public class Chlorocoing : Medicament
    {
        public Chlorocoing(uint qte) : base("Chlorocoing", () => { Console.WriteLine("Chlorocoing"); }, qte,
            Resources.Load<Sprite>("Sprites/Medicaments/mure"))
        { }
    }
}