using System;
using UnityEngine;

namespace C__Scripts.Item
{
    public class Chevre : Item
    {
        public static int Nbr;

        public Chevre(uint qte) : base("Chevre", () => { Console.WriteLine("beeeHEHEheheEEe"); }, qte,
            Resources.Load<Sprite>("Sprites/Medicaments/mure"))
        {
            Nbr++;
        }
    }
}