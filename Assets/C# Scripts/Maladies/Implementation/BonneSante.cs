using Maladies.Base;
using Maladies.Base.SubTypes;

namespace Maladies.Implementation
{
    public class BonneSante : Maladie
    {
        public BonneSante() : base("En Bonne Santé", new TupleValue(60,80),new TupleValue(35,37), true, new TupleValue(0,9))
        { }
    }
}