using TypeExpand._Uint_Uint_;
using Interfaces.Maladies.Types;

namespace GameCore.TypeExpand.Value
{
    public static class Random
    {
        public static uint RandomUint(this ITupleValue input)
        {
            return input.Value.RandomUint();
        }
    }
}