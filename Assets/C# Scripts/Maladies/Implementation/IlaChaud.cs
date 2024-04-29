using Maladies.Base;
using Maladies.Base.SubTypes;

namespace Maladies.Implementation
{
    public class IlaChaud : Malade
    {
        public IlaChaud() : base("IlaChaud", new TupleValue(100,120),new TupleValue(39,43))
        { }
        
    }
}