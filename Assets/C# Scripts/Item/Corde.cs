using System;
using UnityEngine;

namespace C__Scripts.Item
{
    public class Corde : Item
    {
        public static int Nbr = 0;

        public Corde(uint qte) : base("Corde", () => { Console.WriteLine("Corde"); }, 1,
            Resources.Load<Sprite>("Sprites/Medicaments/mure"))
        {
            Nbr++;
        }
    }
}