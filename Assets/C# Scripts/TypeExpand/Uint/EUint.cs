namespace TypeExpand.UInt
{
    public static class EUint
    {
        /// <summary>
        /// Vérifie si une valeur uint est comprise entre deux bornes spécifiées
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool EstEntre(this uint value, uint min, uint max)
        {
            return value >= min && value <= max;
        }
    }
}