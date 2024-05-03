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
        
        public static int RandomInt(this int value)
        {
            return UnityEngine.Random.Range(0, value);
        }
    }
}