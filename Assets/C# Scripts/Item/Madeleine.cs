using System;
using UnityEngine;

namespace C__Scripts.Item
{
    public class Madeleine : Item
    {
        public static int Nbr;

        public Madeleine(uint qte) : base("Madeleine", () => { Console.WriteLine("Madeleine"); }, qte,
            Resources.Load<Sprite>("Sprites/Medicaments/mure"))
        {
            Nbr++;
        }
        
    }
}