﻿using System;
using Items.Base;
using UnityEngine;

namespace Items.Implementation
{
  public class Oeil : Base.Item
  {
    public static int Nbr;

    public Oeil(uint qte) : base("Oeil", () => { Console.WriteLine("Un Oeil, ça glisse."); }, qte,
      Resources.Load<Sprite>("Sprites/Medicaments/mure"))
    {
      Nbr++;
    }
  }
}