﻿using System;
using Items.Base;
using UnityEngine;

namespace Items.Implementation
{
    public class Chevre : Item
    {
        public static int Nbr;

        public Chevre(uint qte) : base("Chevre", () => { Console.WriteLine("beeeHEHEheheEEe"); }, qte,
            Resources.Load<Sprite>("Sprites/Items/chevre"))
        {
            Nbr++;
        }
    }
}