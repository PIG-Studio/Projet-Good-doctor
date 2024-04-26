using System;
using Medicaments.Base;
using UnityEngine;

namespace Medicaments.Implemtation
{
    public class Cyamure : Medicament
    {
        public Cyamure(uint qte) : base("Cyamure", () => { Console.WriteLine("Cyamure"); }, qte,
            Resources.Load<Sprite>("Sprites/Medicaments/mure"))
        {
        }
    }
}