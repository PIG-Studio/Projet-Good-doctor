namespace GameCore.TypeExpand.UInt
{
    public static class EUint
    {
        public static bool EstEntre(this uint value, uint min, uint max)
        {
            return value >= min && value <= max;
        }
    }
}