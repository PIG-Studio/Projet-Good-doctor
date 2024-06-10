namespace TypeExpand.Float
{
    public static class EFloat
    {
        /// <summary>
        /// Calcule la valeur absolue d'un nombre flottant.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float Abs(this float value)
        {
            return value < 0 ? -value : value;
        }
    }
}