using TypeExpand.UInt;
using Interfaces.Maladies.Types;

namespace TypeExpand.Value
{
    public class FreqCar
    {
        /// <summary>
        /// Vérifie si la fréquence cardiaque du patient est mortelle.
        /// </summary>
        /// <param name="freqCarPatient"></param>
        /// <returns></returns>
        public static bool Mortel(IValue freqCarPatient)
        {
            return !freqCarPatient.Valeur.EstEntre(10, 150);
        }
    }
}