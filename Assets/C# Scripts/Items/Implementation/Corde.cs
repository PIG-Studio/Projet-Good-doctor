using System;
using Items.Base;
using UnityEngine;

namespace Items.Implementation
{
    public class Corde : Base.Item
    {
        public static int Nbr;

        public Corde(uint qte) : base("Corde", () => { Console.WriteLine("Corde"); }, qte,
            Resources.Load<Sprite>("Sprites/Medicaments/mure"))
        {
            Nbr++;
        }
    }
}