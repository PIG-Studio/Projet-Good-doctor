using System;
using Items.Base;
using UnityEngine;

namespace Items.Implementation
{
    public class Corde : Item
    {
        public static int Nbr;

        public Corde(uint qte) : base("Corde", () => { Console.WriteLine("Corde"); }, qte,
            Resources.Load<Sprite>("Sprites/Items/corde"))
        {
            Nbr++;
        }
    }
}