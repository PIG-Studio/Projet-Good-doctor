using System;
using UnityEngine;

namespace C__Scripts.Medicaments
{
   
    public class Ibuprofigue : Medicament
    {
        public Ibuprofigue(uint qte) : base("Ibuprofigue", () => { Console.WriteLine("Ibuprofigue"); }, qte,
            Resources.Load<Sprite>("Sprites/Medicaments/figue")) 
        { }
    }
    
}