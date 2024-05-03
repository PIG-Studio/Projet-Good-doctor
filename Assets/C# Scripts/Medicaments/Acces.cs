using Medicaments.Implemtation;
using JetBrains.Annotations;

namespace Medicaments
{
    /// <summary>
    /// Classe listant les methodes pour creer des medicaments 
    /// </summary>
    public static class Acces

    {

        /// <summary>
        /// methode creant une nouvelle instance de cyamure
        /// </summary>
        /// <param name="qte">La quantite a creer</param>
        /// <returns></returns>
        [NotNull]
        public static Cyamure Cyamure(uint qte)
        {
            return new Cyamure(qte);
        }


        public static Ananadvil Ananadvil(uint qte)
        {
            return new Ananadvil(qte);
        }

        public static Chlorocoing Chlorocoing(uint qte)
        {
            return new Chlorocoing(qte);
        }

        public static Doliprune Doliprune(uint qte)
        {
            return new Doliprune(qte);
        }

        public static Ibuprofigue Ibuprofigue(uint qte)
        {
            return new Ibuprofigue(qte);
        }

        public static Lisopoirine Lisopoirine(uint qte)
        {
            return new Lisopoirine(qte);
        }

        public static Opiomelon Opiomelon(uint qte)
        {
            return new Opiomelon(qte);
        }

        public static Oxycodatte Oxycodatte(uint qte)
        {
            return new Oxycodatte(qte);
        }

    }
}