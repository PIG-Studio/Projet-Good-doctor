using System;
using UnityEngine;

namespace C__Scripts.Item
{
    public class Coffee: Item
    {
        public static int Nbr;

        public Coffee(uint qte) : base("Ananadvil", () => { Console.WriteLine("Ananadvil"); }, qte,
            Resources.Load<Sprite>("Sprites/Medicaments/mure"))
        {
            Nbr++;
        }
    }
}