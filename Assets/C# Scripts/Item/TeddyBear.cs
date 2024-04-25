using System;
using UnityEngine;

namespace C__Scripts.Item
{
    public class TeddyBear : Item
    {
        public static int Nbr = 0;

        public TeddyBear(uint qte) : base("TeddyBear", () => { Console.WriteLine("TeddyBear"); }, 1,
            Resources.Load<Sprite>("Sprites/Medicaments/mure"))
        {
            Nbr++;
        }
    }
}