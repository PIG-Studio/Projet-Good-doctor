using Interfaces.Maladies.Types;

namespace Maladies.Base.SubTypes
{
    public class TupleValue : ITupleValue
    {
        public (uint, uint) Value { get; }

        public TupleValue(uint min, uint max)
        {
            Value = (min, max);
        }
        
    }
}