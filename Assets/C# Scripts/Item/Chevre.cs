using System;
using UnityEngine;

namespace C__Scripts.Item
{
    public class Chevre : Item
    {
        public static int Nbr = 0;

        public Chevre(uint qte) : base("Chevre", () => { Console.WriteLine("beeeHEHEheheEEe"); }, 1,
            Resources.Load<Sprite>("Sprites/Medicaments/mure"))
        {
            Nbr++;
        }
    }
}