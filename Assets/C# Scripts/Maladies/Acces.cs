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
        /// array ne contenant que les maladies
        /// </summary>
        private static readonly IMaladie[] Maladies =
        {
            Porcelaine()
        };
        
        private static IMaladie RandMaladie()
        {
            return Acces.Maladies[Acces.Maladies.Length.RandomInt()];
        }
        
        public static (IMaladie maladie, bool ment) GenererRandom()
        {
            IMaladie maladie;
            int lie = 10.RandomInt();
            maladie = lie == 0 ? Bonnesante() : RandMaladie();

            return (maladie, lie==0);
        }

    }
}