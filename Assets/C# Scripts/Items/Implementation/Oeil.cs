using System;
using Items.Base;
using UnityEngine;

namespace Items.Implementation
{
  public class Oeil : Item
  {
    public static int Nbr;

    public Oeil(uint qte) : base("Oeil", () => { Console.WriteLine("Un Oeil, ça glisse."); }, qte,
      Resources.Load<Sprite>("Sprites/Items/Oeil"))
    {
      Nbr++;
    }
  }
}