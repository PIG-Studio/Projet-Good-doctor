using System.Diagnostics.CodeAnalysis;

namespace GameCore.TypeExpand
{
    public static class Uint
    {
        private static bool EstEntre(this int value, int min, int max)
        {
            return value >= min && value <= max;
        }
        
        public static bool MortelleFreqCar(this int value)
        {
            return !value.EstEntre(10, 150);
        }
    }
}