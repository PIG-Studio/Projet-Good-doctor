using System;
using UnityEngine;

namespace C__Scripts.Item
{
    public class Corde : Item
    {
        public static int Nbr;

        public Corde(uint qte) : base("Corde", () => { Console.WriteLine("Corde"); }, qte,
            Resources.Load<Sprite>("Sprites/Medicaments/mure"))
        {
            Nbr++;
        }
    }
}