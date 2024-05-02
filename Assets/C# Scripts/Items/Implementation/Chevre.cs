using System;
using Items.Base;
using UnityEngine;

namespace Items.Implementation
{
    public class Chevre : Base.Item
    {
        public static int Nbr;

        public Chevre(uint qte) : base("Chevre", () => { Console.WriteLine("beeeHEHEheheEEe"); }, qte,
            Resources.Load<Sprite>("Sprites/Medicaments/mure"))
        {
            Nbr++;
        }
    }
}