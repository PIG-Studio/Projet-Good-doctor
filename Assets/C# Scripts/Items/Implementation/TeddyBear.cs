using System;
using Items.Base;
using UnityEngine;

namespace Items.Implementation
{
    public class TeddyBear : Item
    {
        public static int Nbr;

        public TeddyBear(uint qte) : base("TeddyBear", () => { Console.WriteLine("TeddyBear"); }, qte,
            Resources.Load<Sprite>("Sprites/Items/teddybear1"))
        {
            Nbr++;
        }
    }
}