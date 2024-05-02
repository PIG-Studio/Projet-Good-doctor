﻿using System;
using UnityEngine;
using Items.Base;

namespace Items.Implementation
{
    public class Coffee: Base.Item
    {
        public static int Nbr;

        public Coffee(uint qte) : base("Ananadvil", () => { Console.WriteLine("Ananadvil"); }, qte,
            Resources.Load<Sprite>("Sprites/Medicaments/mure"))
        {
            Nbr++;
        }
    }
}