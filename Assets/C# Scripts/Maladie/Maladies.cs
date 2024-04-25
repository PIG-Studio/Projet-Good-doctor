using System;
using System.Collections.Generic;

namespace C__Scripts.Maladie
{
    public static class Maladies
    {
        public static BonneSante BONNESANTE() 
        {// Si le patient n'a pas de maladie il est en bonne santé (stat par défaut)
            return new BonneSante();
        }
        public static SyndromePorcelaine PORCELAINE()
        {
            return new SyndromePorcelaine();
        }

        public static Maladie[] Maladiess = new[]
        {
            (PORCELAINE())
        };

    }
}