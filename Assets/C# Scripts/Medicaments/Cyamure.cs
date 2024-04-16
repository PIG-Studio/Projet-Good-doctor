using System;
using UnityEngine;

public class Cyamure : Medicament
{
    public Cyamure(uint qte) : base("Cyamure", () => { Console.WriteLine("Cyamure"); }, qte,
        Resources.Load<Sprite>("Sprites/Medicaments/mure"))
    { }
}