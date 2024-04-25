using System;
using UnityEngine;

namespace C__Scripts.Item
{
    public class TeddyBear : Item
    {
        public static int Nbr;

        public TeddyBear(uint qte) : base("TeddyBear", () => { Console.WriteLine("TeddyBear"); }, qte,
            Resources.Load<Sprite>("Sprites/Medicaments/mure"))
        {
            Nbr++;
        }
    }
}