using System;
using Items.Base;
using UnityEngine;

namespace Items.Implementation
{
    public class PostIt : Item
    {
        public static int Nbr;

        public PostIt(uint qte) : base("PostIt",
            () => { Console.WriteLine("Un post-it avec ércit \" Tu es viré. \" dessus."); }, qte,
            Resources.Load<Sprite>("Sprites/items/postit"))
        {
            Nbr++;
        }
    }
}