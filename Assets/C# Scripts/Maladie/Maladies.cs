using System;
using System.Collections.Generic;

namespace C__Scripts.Maladie
{
    public static class Maladies
    {
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