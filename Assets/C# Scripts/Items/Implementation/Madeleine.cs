﻿using System;
using Items.Base;
using UnityEngine;

namespace Items.Implementation
{
    public class Madeleine : Base.Item
    {
        public static int Nbr;

        public Madeleine(uint qte) : base("Madeleine", () => { Console.WriteLine("Madeleine"); }, qte,
            Resources.Load<Sprite>("Sprites/Items/sachet-madeleinespng"))
        {
            Nbr++;
        }
        
        
    }
}