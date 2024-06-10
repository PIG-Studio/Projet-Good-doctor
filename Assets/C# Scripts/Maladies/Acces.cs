using Interfaces.Maladies;
using Maladies.Implementation;
using TypeExpand.Int;

namespace Maladies
{
    public static class Acces
    {
        private static BonneSante Bonnesante() 
        {// Si le patient n'a pas de maladie il est en bonne santé (stat par défaut)
            return new BonneSante();
        }
        private static SyndromePorcelaine Porcelaine()
        {
            return new SyndromePorcelaine();
        }

        /// <summary>
        /// Array ne contenant que les maladies
        /// </summary>
        private static readonly IMaladie[] Maladies =
        {
            Porcelaine()
        };
        
        /// <summary>
        /// Méthode pour sélectionner aléatoirement une maladie parmi celles disponibles
        /// </summary>
        /// <returns></returns>
        private static IMaladie RandMaladie()
        {
            return Acces.Maladies[Acces.Maladies.Length.RandomInt()];
        }
        
        /// <summary>
        /// Méthode pour générer aléatoirement une maladie pour un patient
        /// </summary>
        /// <returns></returns>
        public static (IMaladie maladie, bool ment) GenererRandom()
        {
            IMaladie maladie;
            int lie = 10.RandomInt();
            maladie = lie == 0 ? Bonnesante() : RandMaladie();

            return (maladie, lie==0);
        }

    }
}