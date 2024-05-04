using TypeExpand.UInt;
using Interfaces.Maladies.Types;

namespace TypeExpand.Value
{
    public class FreqCar
    {
        public static bool Mortel(IValue freqCarPatient)
        {
            return !freqCarPatient.Valeur.EstEntre(10, 150);
        }
    }
}