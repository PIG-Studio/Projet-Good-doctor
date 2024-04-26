using System;
using Medicaments.Base;
using UnityEngine;

namespace Medicaments.Implemtation
{
   
    public class Ibuprofigue : Medicament
    {
        public Ibuprofigue(uint qte) : base("Ibuprofigue", () => { Console.WriteLine("Ibuprofigue"); }, qte,
            Resources.Load<Sprite>("Sprites/Medicaments/figue")) 
        { }
    }
    
}