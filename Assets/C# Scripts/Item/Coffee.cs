using System;
using UnityEngine;

namespace C__Scripts.Item
{
    public class Coffee: Item
    {
        public static int Nbr = 0;

        public Coffee(uint qte) : base("Ananadvil", () => { Console.WriteLine("Ananadvil"); }, 1,
            Resources.Load<Sprite>("Sprites/Medicaments/mure"))
        {
            Nbr++;
        }
    }
}