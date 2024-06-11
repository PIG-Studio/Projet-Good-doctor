using System;
using UnityEngine;
using Items.Base;

namespace Items.Implementation
{
    public class Foie : Item
    {
        public static int Nbr;
        public Foie(uint qte) : base("Foie", () => { Console.WriteLine("Un foie"); }, qte,
            Resources.Load<Sprite>("Sprites/Items/foie1"))
        {
            Nbr++;
        }
    }
}