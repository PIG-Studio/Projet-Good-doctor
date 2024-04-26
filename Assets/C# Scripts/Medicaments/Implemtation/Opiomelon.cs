using System;
using Medicaments.Base;
using UnityEngine;

namespace Medicaments.Implemtation
{
    public class Opiomelon : Medicament
    {
        public Opiomelon(uint qte) : base("Opiomelon", () => { Console.WriteLine("Opiomelon"); }, qte,
            Resources.Load<Sprite>("Sprites/Medicaments/mure"))
        { }
    }
}