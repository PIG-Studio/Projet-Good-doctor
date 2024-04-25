using System;
using UnityEngine;

namespace C__Scripts.Item
{
  public class Oeil : Item
  {
    public static int Nbr = 0;

    public Oeil(uint qte) : base("Oeil", () => { Console.WriteLine("Un Oeil, ça glisse."); }, 1,
      Resources.Load<Sprite>("Sprites/Medicaments/mure"))
    {
      Nbr++;
    }
  }
}