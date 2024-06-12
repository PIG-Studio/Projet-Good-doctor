using TypeExpand._Uint_Uint_;
using Super.Interfaces.Maladies.Types;

namespace TypeExpand.Value
{
    public static class Random
    {
        /// <summary>
        /// Génère un nombre aléatoire de type uint à partir d'une plage de valeurs spécifiée.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static uint RandomUint(this ITupleValue input)
        {
            return input.Value.RandomUint();
        }
    }
}