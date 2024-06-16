using System;

namespace TypeExpand.Int
{
    public static class EInt
    {
        /*
        private static bool EstEntre(this int value, int min, int max)
        {
            return value >= min && value <= max;
        }
        */
        
        /// <summary>
        /// Génère un nombre entier aléatoire entre zéro et la valeur spécifiée
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int RandomInt(this int value)
        {
            return  new Random().Next(0, value);
        }
    }
}