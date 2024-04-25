using System;
using UnityEngine;

namespace C__Scripts.Item
{
    public class Foie : Item
    {
        public static int Nbr = 0;
        public Foie(uint qte) : base("Foie", () => { Console.WriteLine("Un foie"); }, 1,
            Resources.Load<Sprite>("Sprites/Medicaments/mure"))
        {
            Nbr++;
        }
    }
}