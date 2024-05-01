namespace TypeExpand.Float
{
    public static class EFloat
    {
        public static float Abs(this float value)
        {
            return value < 0 ? -value : value;
        }
    }
}