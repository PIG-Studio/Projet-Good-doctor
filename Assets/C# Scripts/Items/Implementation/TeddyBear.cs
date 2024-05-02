using System;
using Items.Base;
using UnityEngine;

namespace Items.Implementation
{
    public class TeddyBear : Base.Item
    {
        public static int Nbr;

        public TeddyBear(uint qte) : base("TeddyBear", () => { Console.WriteLine("TeddyBear"); }, qte,
            Resources.Load<Sprite>("Sprites/Medicaments/mure"))
        {
            Nbr++;
        }
    }
}