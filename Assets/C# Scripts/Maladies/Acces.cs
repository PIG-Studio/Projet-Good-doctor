using Interfaces.Maladies;
using Maladies.Implementation;

namespace Maladies
{
    public static class Acces
    {
        public static BonneSante Bonnesante() 
        {// Si le patient n'a pas de maladie il est en bonne santé (stat par défaut)
            return new BonneSante();
        }
        public static SyndromePorcelaine Porcelaine()
        {
            return new SyndromePorcelaine();
        }

        /// <summary>
        /// array ne contenant que les maladies
        /// </summary>
        public static readonly IMaladie[] Maladies =
        {
            Porcelaine()
        };

    }
}