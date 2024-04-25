using System;
using UnityEngine;

namespace C__Scripts.Item
{
    public class PostIt : Item
    {
        public static int Nbr;

        public PostIt(uint qte) : base("PostIt",
            () => { Console.WriteLine("Un post-it avec ércit \" Tu es viré. \" dessus."); }, qte,
            Resources.Load<Sprite>("Sprites/Medicaments/mure"))
        {
            Nbr++;
        }
    }
}