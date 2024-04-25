using System;
using UnityEngine;

namespace C__Scripts.Item
{
    public class PostIt : Item
    {
        public static int Nbr = 0;

        public PostIt(uint qte) : base("PostIt",
            () => { Console.WriteLine("Un post-it avec ércit \" Tu es viré. \" dessus."); }, 1,
            Resources.Load<Sprite>("Sprites/Medicaments/mure"))
        {
            Nbr++;
        }
    }
}